using System;
using System.Collections.Generic;
using System.Linq;


namespace BusinessLogic
{
    #region Validator Parent Class
    public class Validator
    {
        #region Constructor
        public Validator()
        {
            m_ValidationRules = new List<Validator>();
        }
        #endregion

        #region Member Variables
        private List<Validator> m_ValidationRules;
        #endregion

        #region Validator Methods
        public void AddValidationRule(Validator pValidator)
        {
            m_ValidationRules.Add(pValidator);
        }

        public virtual bool InputValidator(string pInput, out string pError)
        {
            pError = "oops";
            return false;
        }

        public bool ValidateInput(Validator pValidator, string pInput, out string pError)
        {
            pError = "";
            bool valid = true;
            foreach (Validator rules in pValidator.m_ValidationRules)
            {
                // This is breaking things
//                if (!rules.InputValidator(pInput, out string newError))
//                {
//                    pError += newError;
//                    valid = false;
//                }
            }
            return valid;
        }
        #endregion
    }
    #endregion
    #region Validator Child Classes

    #region CheckISNotNull
    public class CheckIsNotNull : Validator
    {
        #region InputValidator
        public override bool InputValidator(string pInput, out string pError)
        {
            pError = "";
            bool valid = true;
            if (pInput != null)
            {
                return valid;
            }
            pError = "cannot be empty\r\n";
            return false;
        }
        #endregion
    }
    #endregion

    #region CheckIsNotWhiteSpace
    public class CheckIsNotWhiteSpace : Validator
    {
        #region InputValidator
        public override bool InputValidator(string pInput, out string pError)
        {
            pError = "";
            bool valid = true;
            if (pInput.Trim().Length != 0)
            {
                return valid;
            }
            pError = "cannot be white space\r\n";
            return false;
        }
        #endregion
    }
    #endregion

    #region CheckNumberOfCharacters
    public class CheckNumberOfCharacters : Validator
    {
        #region Member Variables
        private int m_NumberOfCharacters;
        #endregion

        #region Constructor
        public CheckNumberOfCharacters(int pNumberOfCharacters)
        {
            m_NumberOfCharacters = pNumberOfCharacters;
        }
        #endregion

        #region Input Validator
        public override bool InputValidator(string pInput, out string pError)
        {
            pError = "";
            pInput.Replace(" ", string.Empty);
            pInput.Trim();
            if (pInput.Length != m_NumberOfCharacters)
            {
                pError += "should have " + m_NumberOfCharacters + " characters\r\n";
                return false;
            }
            return true;
        }
        #endregion

    }
    #endregion

    #region CheckIsAllDigits
    public class CheckIsAllDigits : Validator
    {
        #region InputValidator
        public override bool InputValidator(string pInput, out string pError)
        {
            pError = "";
            pInput.Replace(" ", string.Empty);
            foreach (char c in pInput)
            {
                if (c < '0' || c > '9')
                    pError = "must be all digits 0-9\r\n";
                return false;
            }
            return true;
        }
        #endregion
    }
    #endregion

    #region CheckForSpecialCharacters
    public class CheckForSpecialCharacters : Validator
    {
        #region Member Variables
        private char[] m_CharArray;
        #endregion

        #region Constructor
        public CheckForSpecialCharacters(char[] p_CharArray)
        {
            m_CharArray = new char[p_CharArray.Length];
            for (int i = 0; i < p_CharArray.Length; i++)
            {
                m_CharArray[i] = p_CharArray[i];
            }
        }
        #endregion

        #region InputValidator
        public override bool InputValidator(string pInput, out string pError)
        {
            pError = "";
            bool valid = false;
            foreach (char x in m_CharArray)
            {
                if (pInput.Contains(x))
                {
                    valid = true;
                }
                else
                {
                    pError += string.Format("does not contain the character {0}\r\n", x);
                }
            }
            return valid;
        }
        #endregion
    }
    #endregion

    #region CheckIsAllLetters
    public class CheckIsAllLetters : Validator
    {
        #region InputValidator
        public override bool InputValidator(string pInput, out string pError)
        {
            pError = "";
            string lower = "";
            lower = pInput.ToLowerInvariant();
            lower.Replace(" ", string.Empty);
            foreach (char c in lower)
            {
                if (c < 'a' || c > 'z')
                    pError = "must be all letters a-z\r\n";
                return false;
            }
            return true;
        }
        #endregion


    }
    #endregion

    #region CheckEmailFormat
    public class CheckEmailFormat : Validator
    {
        #region InputValidator
        public override bool InputValidator(string pInput, out string pError)
        {
            char[] chars = pInput.ToCharArray();
            pError = "";
            int index1 = Array.IndexOf(chars, '@');
            int index2 = Array.IndexOf(chars, '.');
            if (index1 == 0 || index1 + 1 >= index2)
            {
                pError += "is in incorrect format";
                return false;
            }
            return true;
        }
        #endregion


    }
    #endregion

    #endregion

}

