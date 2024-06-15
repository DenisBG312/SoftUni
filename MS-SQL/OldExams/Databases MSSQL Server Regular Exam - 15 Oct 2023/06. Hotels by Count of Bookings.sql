SELECT 
		h.Id,
		h.[Name]
  FROM Hotels
    AS h
  JOIN HotelsRooms AS ho ON h.Id = ho.HotelId
  JOIN Rooms AS r ON ho.RoomId = r.Id
  JOIN Bookings AS b ON h.Id = b.HotelId
  WHERE r.[Type] = 'VIP Apartment'
  GROUP BY h.Id, h.[Name]
  ORDER BY COUNT(b.Id) DESC
