namespace ParkingLotSimulation
{
    public class ParkingTicket
    {
        public string? VehicleNumber { get; set; }
        public int SlotNumber { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
    }
}
