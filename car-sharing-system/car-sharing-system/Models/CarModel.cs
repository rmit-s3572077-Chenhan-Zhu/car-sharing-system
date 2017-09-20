﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Diagnostics;

namespace car_sharing_system.Models {
	public class CarModel {
		private static CarModel carModel;
		public List<Car> cars;

		public static CarModel getInstance() {
			if (carModel == null) {
				carModel = new Models.CarModel();
			}
			return carModel;
		}

		// Constructor
		private CarModel() {
		}

		public void refreshCars() {
			cars = DatabaseReader.carQuery(null);
			if (cars == null) {
				generateDummy(cars);
			}
		}

		// Grab random cars just for tests
		public List<Car> getRandomCars() {
			// Grab random car from cars data
			List<Car> randCars = new List<Car>();
			Random rand = new Random();
			int ran1 = rand.Next(1, 10);
			int ran2 = rand.Next(11, 20);
			int ran3 = rand.Next(21, 30);
			int ran4 = rand.Next(31, 40);
			int ran5 = rand.Next(51, 60);

			int[] randomInt = { ran1, ran2, ran3, ran4, ran5 };

			foreach (int i in randomInt) {
				randCars.Add(cars[i]);
			}
			return randCars;
		}

		// Create dummy data in case database isn't working
		public void generateDummy(List<Car> cars) {
			Location latlong1 = new Location(-37.816261m, 144.970976m);
			Location latlong2 = new Location(-37.815555m, 144.970107m);
			Location latlong3 = new Location(-37.815539m, 144.966278m);
			cars.Add(new Car("V123", latlong1, "Mercedes", "C Series", 5.00));
			cars.Add(new Car("V124", latlong2, "Mercedes", "A Series", 6.00));
			cars.Add(new Car("V125", latlong3, "Mercedes", "S Series", 6.30));
		}

		public List<Car> getCloseCar(Double lat, Double lng) {
			List<Car> dbcars = DatabaseReader.carQuery(null);
			cars = new Search(dbcars).find(lat,lng);
			return cars.GetRange(0,5);
		}

		public List<Car> getPageCar(int page) {
			int fpage = (page * 5) - 5;
			return cars.GetRange(fpage, 5);
		}

		public List<Car> getCloseCarFiltered(Double lat, Double lng,
											int sdate, int edate,
											String brand,
											String seat,
											int sortby,
											String transmission,
											String type,
											bool adv, bool cd,
											bool bt, bool gps,
											bool c, bool rad,
											bool revcam ) {
			StringBuilder query = new StringBuilder();
			if (!brand.Equals("Any")) {
				query.AppendFormat("brand = '{0}' " , brand);
			}

			if (!seat.Equals("Any")) {
				if (query.Length > 0) {
					query.Append("AND ");
				}
				query.AppendFormat("seats = {0} ", seat);
			}

			if (!type.Equals("Any")) {
				if (query.Length > 0) {
					query.Append("AND ");
				}
				query.AppendFormat("vehicleType = '{0}' ", type);
			}

			if (!transmission.Equals("Any")) {
				if (query.Length > 0) {
					query.Append("AND ");
				}
				query.AppendFormat("transmission = '{0}' ", transmission);
			}

			List<Car> dbcars = DatabaseReader.carQuery(query.ToString());
			if (dbcars != null) {
				cars = new Search(dbcars).find(lat, lng);
				return cars.GetRange(0,5);
			} else {
				return null;
			}
		}
	}
}