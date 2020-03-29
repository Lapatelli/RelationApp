using RelationApp.Core.Interfaces.Services;
using System.Text;

namespace RelationApp.BLL.Services
{
    public class RelationAddressService : IRelationAddressService
    {
        public string TransormPostalCode(string postalCode, string postalCodeFormat)
        {
            StringBuilder postalCodeTransformedBuilder = new StringBuilder();
            string postalCodeTransformed;

            const char digit = 'N';
            const char upperLetter = 'L';
            const char lowerLetter = 'l';

            var PostalCodeFormatArray = postalCodeFormat.ToCharArray();
            var PostalCodeArray = postalCode.ToCharArray();

            for (int i = 0, j = 0; i <= PostalCodeArray.Length; i++, j++)
            {
                switch (PostalCodeFormatArray[i])
                {
                    case digit:
                        {
                            if (char.IsDigit(PostalCodeArray[j]))
                                postalCodeTransformedBuilder.Append(PostalCodeArray[j]);
                            else
                            {
                                postalCodeTransformedBuilder.Clear();
                            }
                            break;
                        }
                    case upperLetter:
                        {
                            if (char.IsLetter(PostalCodeArray[j]))
                                postalCodeTransformedBuilder.Append(char.ToUpper(PostalCodeArray[j]));
                            else
                            {
                                postalCodeTransformedBuilder.Clear();
                            }
                            break;
                        }
                    case lowerLetter:
                        {
                            if (char.IsLetter(PostalCodeArray[j]))
                                postalCodeTransformedBuilder.Append(char.ToLower(PostalCodeArray[j]));
                            else
                            {
                                postalCodeTransformedBuilder.Clear();
                            }
                            break;

                        }
                    case '-':
                        {
                            if (PostalCodeArray[i] == '-')
                                postalCodeTransformedBuilder.Append(PostalCodeArray[i]);
                            else
                            {
                                postalCodeTransformedBuilder.Append('-');
                                j--;
                            }
                            break;
                        }
                }

                if (string.IsNullOrEmpty(postalCodeTransformedBuilder.ToString()))
                    break;
            }

            if (string.IsNullOrEmpty(postalCodeTransformedBuilder.ToString()))
                postalCodeTransformed = postalCode;
            else
                postalCodeTransformed = postalCodeTransformedBuilder.ToString();

            return postalCodeTransformed;
        }
    }
}
