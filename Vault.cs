using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using System.Xml;

namespace PasswordVault
{
	// Container class for all elements that make an entry into the vault
	public class VaultItem
	{
		public String Name;
		public String Group;
		public String User;
		public String Password;
		public String Url;
		public String App;
		public String Desc;
	};

    // Structure for holding encryption data
    public class VaultEncoder
    {
        private static String DefaultSalt = "S@lTiNess&p3Pp3R";
        private static int DefaultIters = 1024;
        private static String DefaultInit = "%5eRf0x97#0p_Pi8";
        private static int DefaultKeySize = 256;
        private static String DefaultAlgorithm = "SHA1";
        private PasswordDeriveBytes _passBytes = null;
        private RijndaelManaged _algorithm = null;
        private ICryptoTransform _encryptor = null;
        private ICryptoTransform _decryptor = null;

        // Constructor
        public VaultEncoder(String password)
        {
            // Get password bytes
            _passBytes = new PasswordDeriveBytes(password, 
                Encoding.ASCII.GetBytes(DefaultSalt), DefaultAlgorithm, DefaultIters);

            // Use block chaining for encryption
            _algorithm = new RijndaelManaged();
            _algorithm.Mode = CipherMode.CBC;
            _algorithm.Padding = PaddingMode.PKCS7;
            _algorithm.Key = _passBytes.GetBytes(DefaultKeySize / 8);
            _algorithm.IV = Encoding.ASCII.GetBytes(DefaultInit);

            // Create encoders
            _encryptor = _algorithm.CreateEncryptor();
            _decryptor = _algorithm.CreateDecryptor();
        }

        // Encryption
        public String Encrypt(String input)
        {
            MemoryStream memStr = new MemoryStream();
            CryptoStream cryptStr = new CryptoStream(memStr, _encryptor, CryptoStreamMode.Write);

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Encrypt
            cryptStr.Write(inputBytes, 0, inputBytes.Length);
            cryptStr.FlushFinalBlock();

            // Convert our encrypted data from a memory stream into a byte array.
            byte[] cipherBytes = memStr.ToArray();

            // Close both streams.
            memStr.Close();
            cryptStr.Close();

            // Convert encrypted data into a base64-encoded string.
            return Convert.ToBase64String(cipherBytes);
        }

        // Decryption
        public String Decrypt(String input)
        {
            // Create our streams
            byte[] cipherBytes = Convert.FromBase64String(input);
            MemoryStream memStr = new MemoryStream(cipherBytes);
            CryptoStream cryptStr = new CryptoStream(memStr, _decryptor, CryptoStreamMode.Read);

            // Allocate buffer for reading plain text, we don't know how long it will
            // be so allocate enough to hold the entire thing
            byte[] plainTextBytes = new byte[cipherBytes.Length];

            // Start decrypting.
            int decryptByteCount = cryptStr.Read(plainTextBytes, 0, plainTextBytes.Length);

            // Close both streams.
            memStr.Close();
            cryptStr.Close();

            // Convert decrypted data into a string. 
            // Let us assume that the original plaintext string was UTF8-encoded.
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptByteCount);
        }
    };

	// Container class for all vault items
	public class Vault
	{
		// Static items
		public static String VaultExt = ".pvf";
		public static String Header = "PASSWORD_VAULT_HEADER_0x73ad0e9f";

		// The name of our vault
		private String _name;
		public String Name
		{
			get { return _name;  }
			set { _name = value; }
		}

		// The location of our vault
		private String _fullPath;
		public String FullPath
		{
			get { return _fullPath; }
			set { _fullPath = value; }
		}

		// The password of our vault
		private String _password;
		public String Password
		{
			get { return _password; }
			set { _password = value; }
		}

		// The main form that owns us
		private MainForm _form;
		public MainForm Form
		{
			get { return _form; }
			set { _form = value; }
		}

		// Create the vault list
		private List<VaultItem> _items = new List<VaultItem>();
		public List<VaultItem> Items
		{
			get {return _items;}
		}

		// Callback for when vault changes status
		public delegate void StatusChangeHandler(Vault.VaultStatus status);
		public event StatusChangeHandler StatusChange;
		protected void OnStatusChange(Vault.VaultStatus status)
		{
			// Check if there are any Subscribers
			if (StatusChange != null)
			{
				// Call the Event
				StatusChange(_status);
			}
		}

		// The state of the vault
		private VaultStatus _status;
		public VaultStatus Status
		{
			get { return _status; }
			set 
			{ 
				_status = value;
				OnStatusChange(_status);
			}
		}
		public enum VaultStatus
		{
			Empty,
			Touched,
			UpToDate,
		}

		// Constructor
		public Vault()
		{
		}

		// Static function for loading a vault from disk, returns a vault instance
		public static List<VaultItem> Load(String filename, String password)
		{
			bool error = false;
			List<VaultItem> vaultItems = new List<VaultItem>();
			String data = "";

			// Append the extension if we don't have it already
			if(!filename.Contains(VaultExt))
			{
				filename += VaultExt;
			}

			// Open up a file stream for read
			FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);

			// Create a writer to output the file
			StreamReader reader = new StreamReader(stream);

            // Create Encrypter
            VaultEncoder venc = new VaultEncoder(password);

			try
			{
				// Read in the header
				data = reader.ReadLine();
				data = venc.Decrypt(data);

				// Read in number of entries
				data = reader.ReadLine();
                data = venc.Decrypt(data);

				// Read in all items
				int iItemCount = Int32.Parse(data);
				for (int i = 0; i < iItemCount; i++)
				{
					VaultItem item = new VaultItem();

					data = reader.ReadLine();
                    data = venc.Decrypt(data);
					item.Name = data;

					data = reader.ReadLine();
                    data = venc.Decrypt(data);
					item.Group = data;

					data = reader.ReadLine();
                    data = venc.Decrypt(data);
					item.User = data;

					data = reader.ReadLine();
                    data = venc.Decrypt(data);
					item.Password = data;

					data = reader.ReadLine();
                    data = venc.Decrypt(data);
					item.Url = data;

					data = reader.ReadLine();
                    data = venc.Decrypt(data);
					item.App = data;
					
					data = reader.ReadLine();
                    data = venc.Decrypt(data);
					item.Desc = data;

					// Append to item list to return
					vaultItems.Add(item);
				}
			}
			catch(Exception)
			{
				// The message is handled by the caller and is
				// denoted by a return value of null
				error = true;
			}

			// Close the stream
			stream.Close();
			reader.Close();

			// The was an error on the decrypt, most likely it was a bad password
			if(error)
			{
				return null;
			}

			// Return our vault
			return vaultItems;
		}

		// Saves the vault to disk
		public bool Save(String filename)
		{
			String data = "";

			// Update vault name
			FileInfo info = new FileInfo(filename);
			this.Name = info.Name.Replace(Vault.VaultExt, "");
			this.FullPath = filename;

			// Open up a file stream for write
			FileStream stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);

			// Create a writer to output the file
			StreamWriter writer = new StreamWriter(stream);

            // Create Encrypter
            VaultEncoder venc = new VaultEncoder(Password);

			// Write out header
            data = venc.Encrypt(Header);
			writer.WriteLine(data);

			// Write out number of entries
            data = venc.Encrypt(Items.Count.ToString());
			writer.WriteLine(data);

			// Write out all item
			for (int i = 0; i < Items.Count; i++)
			{
                data = venc.Encrypt(Items[i].Name);
				writer.WriteLine(data);

                data = venc.Encrypt(Items[i].Group);
				writer.WriteLine(data);

                data = venc.Encrypt(Items[i].User);
				writer.WriteLine(data);

                data = venc.Encrypt(Items[i].Password);
				writer.WriteLine(data);

                data = venc.Encrypt(Items[i].Url);
				writer.WriteLine(data);

                data = venc.Encrypt(Items[i].App);
				writer.WriteLine(data);

                data = venc.Encrypt(Items[i].Desc);
				writer.WriteLine(data);
			}

			// Write and close
			writer.Close();
			stream.Close();

			// Let people know we are in sync
            Status = VaultStatus.UpToDate;

			return true;
		}
	}
}
