using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT391_Roberts_Unit6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool ValidationTest = true;
            string ErrorMessages = "";

            //Check for Presence of Values
            if (txtFirstName.TextLength == 0)
            {
                ErrorMessages += "You must enter your First Name.\n";
                ValidationTest = false;
            }
            if (txtLastName.TextLength == 0)
            {
                ErrorMessages += "You must enter your Last Name.\n";
                ValidationTest = false;
            }
            if (txtZipCode.TextLength == 0)
            {
                ErrorMessages += "You must enter your Zip Code.\n";
                ValidationTest = false;
            }
            if (txtEmailAddress.TextLength == 0)
            {
                ErrorMessages += "You must enter your Email Address.\n";
                ValidationTest = false;
            }

            //Check for proper Value Length
            if (txtFirstName.TextLength > 20)
            {
                ErrorMessages += "Entered First Name has too many characters (limit 20).\n";
                ValidationTest = false;
            }
            if (txtLastName.TextLength > 20)
            {
                ErrorMessages += "Entered Last Name has too many characters (limit 20).\n";
                ValidationTest = false;
            }
            if (txtStreetAddress.TextLength > 50)
            {
                ErrorMessages += "Entered Street Address has too many characters (limit 50).\n";
                ValidationTest = false;
            }
            if (txtCity.TextLength > 30)
            {
                ErrorMessages += "Entered City has too many characters (limit 30)\n";
                ValidationTest = false;
            }
            if (txtState.TextLength != 2 && txtState.TextLength != 0)
            {
                ErrorMessages += "Entered State has the wrong number of characters (must be 2)\n";
                ValidationTest = false;
            }
            if (txtZipCode.TextLength != 5 && txtZipCode.TextLength != 0)
            {
                ErrorMessages += "Invalid Zip Code. Required length is 5 characters.\n";
                ValidationTest = false;
            }

            //Check for Valid State
            foreach (char s in txtState.Text)
            {
                if (!Char.IsLetter(s))
                {
                    ErrorMessages += "Invalid State. Please enter correct 2 letter State Code\n";
                    ValidationTest = false;
                    break;
                }
            }

            //Check for Valid Zip Code (Numerals Only)
            foreach (char z in txtZipCode.Text)
            {
                if (z < '0' || z > '9')
                {
                    ErrorMessages += "Invalid Zip Code. Zip Code must only contain numerals.\n";
                    ValidationTest = false;
                    break;
                }
            }

            //Check for Valid Email Address
            string FullEmailAddress, EmailLocal, EmailDomain;
            string[] SplitEmailAddress;
            FullEmailAddress = txtEmailAddress.Text;
            if ((FullEmailAddress.LastIndexOf("@") == FullEmailAddress.IndexOf("@")) && FullEmailAddress.IndexOf("@") != -1)
            {
                SplitEmailAddress = FullEmailAddress.Split('@');
                EmailLocal = SplitEmailAddress[0];
                EmailDomain = SplitEmailAddress[1];
                if (EmailLocal.Length > 64)
                {
                    ErrorMessages += "Entered Email Local Recipient Name has too many characters (limit 64)\n";
                    ValidationTest = false;
                }
                if (EmailDomain.Length > 255)
                {
                    ErrorMessages += "Entered Email Domain Recipient Name has too many characters (limit 255)\n";
                    ValidationTest = false;
                }
                if (FullEmailAddress.Length > 320)
                {
                    ErrorMessages += "Entered Email Address has too many characters (limit 320)\n";
                    ValidationTest = false;
                }

                //Check for Valid Domain
                if (FullEmailAddress.IndexOf(".") == -1)
                {
                    ErrorMessages += "Entered Email Domain is invalid. Please confirm correct domain.\n";
                    ValidationTest = false;
                }
            }
            else if (txtEmailAddress.Text.Length > 0)
            {
                ErrorMessages += "You have entered an invalid Email Address.\n";
                ValidationTest = false;
            }

            //Check for Valid Survey Rating
            if (txtRating.TextLength > 0)
            {
                if (Int32.TryParse(txtRating.Text, out int rating))
                {
                    if (rating < 1 || rating > 10)
                    {
                        ErrorMessages += "You have entered an invalid Rating. Please enter a numeric value between 1 and 10.\n";
                        ValidationTest = false;
                    }
                }
                else
                {
                    ErrorMessages += "You have entered an invalid Rating. Please enter a numeric value between 1 and 10.\n";
                    ValidationTest = false;
                }
            }

            //Display MessageBox based on Validation Results
            if (ValidationTest == true)
            {
                //Declare and Assign form values to their program variable equivalents
                //Declare Variables for Submission
                string FirstName = txtFirstName.Text;
                string MiddleInitial = txtMiddleInitial.Text;
                string LastName = txtLastName.Text;
                //Only assign value if txtAge is not empty
                if (txtAge.TextLength > 0)
                {
                    int Age = Int32.Parse(txtAge.Text);
                }
                string StreetAddress = txtStreetAddress.Text;
                string City = txtCity.Text;
                string State = txtState.Text;
                if (txtZipCode.TextLength > 0)
                {
                    int ZipCode = Int32.Parse(txtZipCode.Text);
                }
                string EmailAddress = txtEmailAddress.Text;
                if (txtRating.TextLength > 0)
                {
                    int Rating = Int32.Parse(txtRating.Text);
                }

                //Confirm to user that data was validated and submitted successfully.
                MessageBox.Show("Data validated and submitted successfully!");
                //Clear contents of form after successful submission
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == typeof(TextBox))
                    {
                        c.Text = "";
                    }
                }
            }
            else
            {
                //Show Error Messages
                MessageBox.Show(ErrorMessages);
            }
        }
    }
}