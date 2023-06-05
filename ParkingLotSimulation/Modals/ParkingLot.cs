namespace ParkingLotSimulation
{
    public class ParkingLot
    {
        public List<ParkingTicket>? Tickets { get; set; }

        public IDictionary<VehicleType, List<ParkingSlot>>? Slots { get; set; }
    }
}
