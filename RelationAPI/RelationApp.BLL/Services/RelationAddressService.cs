using RelationApp.Core.Interfaces.Services;
using System.Text;

namespace RelationApp.BLL.Services
{
    public class RelationAddressService : IRelationAddressService
    {
        /// <summary>
        /// Transform postal code from POST and PUT Methods in Web.Controllers to certain postal code format for certain country
        /// </summary>
        /// <param name="postalCode"></param>
        /// <param name="postalCodeFormat"></param>
        /// <returns></returns>
        public string TransormPostalCode(string postalCode, string postalCodeFormat)
        {
            var postalCodeTransformedBuilder = new StringBuilder();
            string postalCodeTransformed;

            const char digit = 'N';
            const char upperLetter = 'L';
            const char lowerLetter = 'l';

            var postalCodeFormatArray = postalCodeFormat.ToCharArray();
            var postalCodeArray = postalCode.ToCharArray();

            for (int i = 0, j = 0; j <= postalCodeArray.Length-1; i++, j++)
            {
                switch (postalCodeFormatArray[i])
                {
                    case digit:
                        {
                            if (char.IsDigit(postalCodeArray[j]))
                                postalCodeTransformedBuilder.Append(postalCodeArray[j]);
                            else
                            {
                                postalCodeTransformedBuilder.Clear();
                            }
                            break;
                        }
                    case upperLetter:
                        {
                            if (char.IsLetter(postalCodeArray[j]))
                                postalCodeTransformedBuilder.Append(char.ToUpper(postalCodeArray[j]));
                            else
                            {
                                postalCodeTransformedBuilder.Clear();
                            }
                            break;
                        }
                    case lowerLetter:
                        {
                            if (char.IsLetter(postalCodeArray[j]))
                                postalCodeTransformedBuilder.Append(char.ToLower(postalCodeArray[j]));
                            else
                            {
                                postalCodeTransformedBuilder.Clear();
                            }
                            break;
                        }
                    case '-':
                        {
                            if (postalCodeArray[i] == '-')
                            {
                                postalCodeTransformedBuilder.Append(postalCodeArray[i]);
                            }
                            else
                            {
                                postalCodeTransformedBuilder.Append('-');
                                j = char.IsWhiteSpace(postalCodeArray[j]) || char.IsPunctuation(postalCodeArray[j]) ? j : j-1;
                            }
                            break;
                        }
                    default:
                        {
                            postalCodeTransformedBuilder.Clear();
                            break;
                        }
                }

                if (string.IsNullOrEmpty(postalCodeTransformedBuilder.ToString()))
                    break;
            }

            postalCodeTransformed = string.IsNullOrEmpty(postalCodeTransformedBuilder.ToString()) ? postalCode : postalCodeTransformedBuilder.ToString();

            return postalCodeTransformed;
        }
    }
}
