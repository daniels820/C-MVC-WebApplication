using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DAL.EF.EntityFrameworkContext
{
    public class ContextManager
    {
        //public AteraDevServerForInterviewsContext _context;

         public AteraDevServerForInterviewsContext _context = new AteraDevServerForInterviewsContext();

        //My Added methods
        public List<Devices> GetAllDevices()
        {
            Debug.WriteLine("testing- GetAllDevices ");
            Debug.WriteLine(_context.Devices.ToList());

            

            var result = from Devices in _context.Devices
                               where Devices.Created != null
                               select Devices;
                
            return result.ToList();
        }

        public List<Devices> GetDevicesByOwnerName(string owner)
        {
            var db = _context;
            Debug.WriteLine("testing- GetDevicesByOwnerName ");
            Debug.WriteLine(_context.Devices.Where(d => d.Owner.ToString() == owner).FirstOrDefault());

            var query = from Devices in db.Devices
                         join Owners in db.Owners on Devices.OwnerId equals Owners.OwnerId
                         where Owners.FullName==owner
                         select Devices;

            return query.ToList();
        }
    

       
    }
}
