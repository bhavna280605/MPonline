// ============================================================
// Assignment 02: Drone Surveillance System
// Demonstrates: encapsulation, state management, validation
// ============================================================
using System;

namespace DroneSurveillanceSystem
{
    public class Drone
    {
        // --- Private fields (cannot be accessed directly) ---
        private int _batteryLife;     // percentage 0..100
        private double _altitude;     // metres
        private bool _isFlying;

        public string DroneId { get; }
        public string Model   { get; }

        // --- Public read-only accessors ---
        public int BatteryLife => _batteryLife;
        public double Altitude => _altitude;
        public bool IsFlying   => _isFlying;

        public Drone(string id, string model, int initialBattery = 100)
        {
            DroneId    = id;
            Model      = model;
            _batteryLife = initialBattery;
            _altitude    = 0;
            _isFlying    = false;
        }

        // --- Take off ---
        public void TakeOff(double targetAltitude)
        {
            if (_isFlying)
            {
                Console.WriteLine($"[{DroneId}] Already flying at {_altitude} m.");
                return;
            }
            if (_batteryLife < 20)
            {
                Console.WriteLine($"[{DroneId}] Battery too low ({_batteryLife}%). Cannot take off.");
                return;
            }
            if (targetAltitude <= 0)
            {
                Console.WriteLine($"[{DroneId}] Invalid altitude {targetAltitude} m.");
                return;
            }

            _isFlying   = true;
            _altitude   = targetAltitude;
            _batteryLife -= 5;
            Console.WriteLine($"[{DroneId}] Took off. Altitude = {_altitude} m, Battery = {_batteryLife}%");
        }

        // --- Move (only allowed if flying) ---
        public void Move(double horizontalDistance)
        {
            if (!_isFlying)
            {
                Console.WriteLine($"[{DroneId}] Cannot move — drone is NOT flying. Take off first.");
                return;
            }
            if (_batteryLife <= 0)
            {
                Console.WriteLine($"[{DroneId}] Battery dead. Force-landing.");
                Land();
                return;
            }

            _batteryLife -= (int)Math.Ceiling(horizontalDistance / 10.0); // 1% per 10 m
            Console.WriteLine($"[{DroneId}] Moved {horizontalDistance} m horizontally. " +
                              $"Battery = {_batteryLife}%, Altitude = {_altitude} m");
        }

        // --- Land ---
        public void Land()
        {
            if (!_isFlying)
            {
                Console.WriteLine($"[{DroneId}] Already on the ground.");
                return;
            }
            _isFlying = false;
            _altitude = 0;
            _batteryLife -= 2;
            Console.WriteLine($"[{DroneId}] Landed safely. Battery = {_batteryLife}%");
        }

        public void Charge(int amount)
        {
            _batteryLife = Math.Min(100, _batteryLife + amount);
            Console.WriteLine($"[{DroneId}] Charged by {amount}%. Battery = {_batteryLife}%");
        }

        public override string ToString() =>
            $"Drone {DroneId} ({Model}) — Flying={_isFlying}, Alt={_altitude} m, Battery={_batteryLife}%";
    }

    class Program
    {
        static void Main()
        {
            var d = new Drone("DR-01", "SkyHawk-X");

            // Try to move before taking off — should be blocked
            d.Move(50);

            // Take off and operate
            d.TakeOff(120);
            d.Move(35);
            d.Move(80);

            // Try to take off again while flying — should be blocked
            d.TakeOff(200);

            // Land
            d.Land();
            d.Land();   // already on ground

            Console.WriteLine("\nFinal state: " + d);
        }
    }
}
