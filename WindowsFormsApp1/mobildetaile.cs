﻿using main;
using mobile;
using Mobile_Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class mobildetaile
    {
        /// code frist create mobile detailes table with relation one to one 
        #region data
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; private set; }
        [Required]
        public string name { get; set; }
        [Required]
        public double price { get; set; }
        public double screen { get; set; }
        public int storage { get; set; }
        public int ram { get; set; }
        public int battery { get; set; }
        public int front_camera { get; set; }
        public int back_camera { get; set; }
        public string processor { get; set; }
        public string android { get; set; }
        public string network { get; set; }
        [Required]
        public int quantity { get; set; }
        public double warranty { get; set; }
        public string date { get; set; }
  
        public virtual mobile_images Mobile_Images { get;set;}
        public virtual ICollection<Bill> Bills { get; set; }



        accessContext context = new accessContext();
        #endregion

        //add new item and if exist increase with new quantity
        #region add function
        public bool Addnotitmexist(string nms,double prices ,double screens, int storages, int rams, int batterys, int front_cameras, int back_cameras, string processors, string androids, string networks, int quantitys, double warrantys,string dates)
        {
            var datashow = context.mobdetailes.Where(n => n.name == nms).Select(n => n.name).FirstOrDefault();
            if (datashow == null)
            {
                mobildetaile dataobject = new mobildetaile() { name = nms, price = prices, screen = screens, storage = storages, ram = rams, battery = batterys, front_camera = front_cameras, back_camera = back_cameras, processor = processors, android = androids, network = networks, quantity = quantitys, warranty = warrantys, date = dates };
                context.mobdetailes.Add(dataobject);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public void additmexist(string nms, double prices, double screens, int storages, int rams, int batterys, int front_cameras, int back_cameras, string processors, string androids, string networks, int quantitys, double warrantys, string dates)
        {
            var datashow = context.mobdetailes.Where(n => n.name == nms).Select(n => n.name).FirstOrDefault();
            if (datashow != null)
            {
                int q = context.mobdetailes.Where(n => n.name == nms).Select(n => n.quantity).FirstOrDefault();
                int newquantity = q + quantitys;
                int indexrow = context.mobdetailes.Where(m => m.name == nms).Select(m => m.id).FirstOrDefault();
                mobildetaile dataobject = new mobildetaile() { id = indexrow, name = nms, price = prices, screen = screens, storage = storages, ram = rams, battery = batterys, front_camera = front_cameras, back_camera = back_cameras, processor = processors, android = androids, network = networks, quantity = newquantity, warranty = warrantys, date = dates };
                context.Entry(dataobject).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            
        }
        #endregion

        ///function to update searched item
        #region update function
        public bool update(string nms, double prices, double screens, int storages, int rams, int batterys, int front_cameras, int back_cameras, string processors, string androids, string networks, int quantitys, double warrantys, string dates)
        {
            try
            {
                int indexrow = context.mobdetailes.Where(m => m.name == nms).Select(m => m.id).FirstOrDefault();
                mobildetaile dataobject = new mobildetaile() { id = indexrow, name = nms, price = prices, screen = screens, storage = storages, ram = rams, battery = batterys, front_camera = front_cameras, back_camera = back_cameras, processor = processors, android = androids, network = networks, quantity = quantitys, warranty = warrantys, date = dates };
                context.Entry(dataobject).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        }
}
