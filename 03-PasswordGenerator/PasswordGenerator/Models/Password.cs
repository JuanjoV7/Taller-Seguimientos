using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Models
{
    public class Password
    {
        private int _length;
        private bool _useUppercase;
        private bool _useLowercase;
        private bool _useNumbers;
        private bool _useSymbols;

        public Password(int length, bool useUppercase, bool useLowercase, bool useNumbers, bool useSymbols)
        {
            _length = length;
            _useUppercase = useUppercase;
            _useLowercase = useLowercase;
            _useNumbers = useNumbers;
            _useSymbols = useSymbols;
        }

        public bool HasCharacterTypes()
        {
            if (_useUppercase || _useLowercase || _useNumbers || _useSymbols)
            {
                return true;
            }

            return false;
        }

        public string Generate()
        {
            string characters = GetCharacters();
            string password = BuildPassword(characters);

            while (!MeetsRequirements(password))
            {
                password = BuildPassword(characters);
            }

            return password;
        }

        private string GetCharacters()
        {
            string characters = "";

            if (_useUppercase)
            {
                characters = characters + "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }

            if (_useLowercase)
            {
                characters = characters + "abcdefghijklmnopqrstuvwxyz";
            }

            if (_useNumbers)
            {
                characters = characters + "0123456789";
            }

            if (_useSymbols)
            {
                characters = characters + "!@#$%&*?-_+=";
            }

            return characters;
        }

        private string BuildPassword(string characters)
        {
            string password = "";

            for (int i = 0; i < _length; i++)
            {
                int index = RandomNumberGenerator.GetInt32(characters.Length);
                password = password + characters[index];
            }

            return password;
        }

        private bool MeetsRequirements(string password)
        {
            bool hasUppercase = false;
            bool hasLowercase = false;
            bool hasNumber = false;
            bool hasSymbol = false;

            foreach (char character in password)
            {
                if (char.IsUpper(character))
                {
                    hasUppercase = true;
                }
                else if (char.IsLower(character))
                {
                    hasLowercase = true;
                }
                else if (char.IsDigit(character))
                {
                    hasNumber = true;
                }
                else
                {
                    hasSymbol = true;
                }
            }

            if (_useUppercase && !hasUppercase)
            {
                return false;
            }

            if (_useLowercase && !hasLowercase)
            {
                return false;
            }

            if (_useNumbers && !hasNumber)
            {
                return false;
            }

            if (_useSymbols && !hasSymbol)
            {
                return false;
            }

            return true;
        }
    }
}
