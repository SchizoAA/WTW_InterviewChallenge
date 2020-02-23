using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WTW_InterviewChallenge.Functions
{
    /// <summary>
    /// Helper functions for email addresses.
    /// </summary>
    public class EmailAddressHelpers
    {
        private readonly string localRegex = @"^[a-z0-9]*$";
        private readonly string domainRegex = @"[@]{1}[a-z0-9\.]+$";

        /// <summary>
        /// Given a list of email addresses, returns the number of unique email addresses present in the list. 
        /// Email address consists of two parts, local-part and domain name separated by the @ symbol.
        /// Local-part can contain numbers, lower-case letters, '.', and '+' symbols.
        /// Domain name can contain lower-case characters and the '.' symbol.
        /// </summary>
        /// <param name="emails">List of email addresses</param>
        /// <returns>Number of unique email addresses</returns>
        public int NumberOfUniqueEmailAddresses(string[] emails)
        {
            HashSet<string> unique = new HashSet<string>();
            foreach(var email in emails)
            {
                var separator = email.IndexOf("@");
                var localPart = FormatLocal(email.Substring(0, separator));
                var domain = email.Substring(separator);
                if(!Regex.IsMatch(localPart, localRegex) || !Regex.IsMatch(domain, domainRegex)) //Local-part or domain contains invalid characters. Skip entry.
                {
                    continue;
                }
                var formattedEmail = localPart + domain;
                unique.Add(formattedEmail);
            }
            return unique.Count;
        }

        /// <summary>
        /// Formats local-part string to remove substring after '+' and remove '.' symbols.
        /// </summary>
        /// <param name="localPart">local-part string to format</param>
        /// <returns>formatted string</returns>
        private string FormatLocal(string localPart)
        {
            string result = localPart.ToLower();

            //When a plus is placed in the local name, everything after the plus symbol will be ignored.
            var plusIndex = localPart.IndexOf("+");
            if (plusIndex > 0)
            {
                result = localPart.Substring(0, plusIndex);
            }

            //When a period is placed between characters in the name, the email is delivered to the same address as if the periods were not included. 
            //For example an email sent to first.m.last@somewhere.com will be delivered to the same address as firstmlast@somewhere.com. 
            result = result.Replace(".", "");
            return result;
        }
    }
}
