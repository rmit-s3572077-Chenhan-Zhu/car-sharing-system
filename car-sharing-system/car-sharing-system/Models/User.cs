﻿using Rework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace car_sharing_system.Models
{

    public class User
    {
        public int id { get; private set; }
        public String email { get; private set; }
        public String password { get; private set; }
        public int permission { get; private set; }
        public String licenseNo { get; private set; }
        public String fname { get; private set; }
        public String lname { get; private set; }
        public String gender { get; private set; }
        public String birth { get; private set; }
        public String phone { get; private set; }
        public String street { get; private set; }
        public String suburb { get; private set; }
        public String postcode { get; private set; }
        public String territory { get; private set; }
        public String city { get; private set; }
        public String country { get; private set; }
        public String profileURL { get; private set; }

        public User() {
        }
        public User(int id,
            String email,
            String password,
            int permission,
            String licenseNo,
            String fname,
            String lname,
            String gender,
            String birth,
            String phone,
            String street,
            String suburb,
            String postcode,
            String territory,
            String city,
            String country,
            String profileURL)
        {



            this.id = id;
            this.email = email;
            this.password = hashMe(password);
            this.permission = permission;
            this.licenseNo = licenseNo;
            this.fname = fname;
            this.lname = lname;
            this.gender = gender;
            this.birth = birth;
            this.phone = phone;
            this.street = street;
            this.suburb = suburb;
            this.postcode = postcode;
            this.territory = territory;
            this.city = city;
            this.country = country;
            this.profileURL = profileURL;
        }
        public String hashMe(String password)
        {
            return (password + "CarSharing2017").ToSHA(Crypto.SHA_Type.SHA512);
        }
        public Boolean nullChecker() {
            if (id.Equals(null) || email.Equals(null) || password.Equals(null) || 
                permission.Equals(null) || licenseNo.Equals(null) || fname.Equals(null) || 
                lname.Equals(null) || gender.Equals(null) || birth.Equals(null) || phone.Equals(null) || 
                street.Equals(null) || suburb.Equals(null) || postcode.Equals(null) || 
                territory.Equals(null) ||  city.Equals(null) || country.Equals(null))
                return false;
            return true;
        }
        public String toString()
        {
            return "ID: " + id + "<br />" +
                "Email: " + email + "<br />" +
                "Password: " + password + "<br />" +
                "Permission: " + permission + "<br />" +
                "licenseNo: " + licenseNo + "<br />" +
                "First Name: " + fname + "<br />" +
                "Last Name: " + lname + "<br />" +
                "Gender: " + gender + "<br />" +
                "Date Of Birth: " + birth + "<br />" +
                "Phone: " + phone + "<br />" +
                "Street: " + street + "<br />" +
                "Suburb: " + suburb + "<br />" +
                "Postcode: " + postcode + "<br />" +
                "Territory: " + territory + "<br />" +
                "City: " + city + "<br />" +
                "Country: " + country + "<br />" +
                "ProfileURL: " + profileURL + "<br />";


        }
    }
}