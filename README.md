# SmartRooms API

**A RESTful API for managing and monitoring smart classrooms in the SmartRooms project.**

---

## Features

- **Real-time room status**: Retrieve environmental data such as temperature, humidity, and harmful gases
- **Actuator control**: Enable or disable devices like lights and air conditioning remotely
- **Room information**: Access details about ongoing classes, teachers, and schedules
- **Localization support**: Provide room locations and directions within the building

---

## Endpoints

### Room Status
Retrieve environmental conditions for a specific room.

**GET** `/api/rooms/{roomId}/status`  
- **Parameters**:  
  `roomId` - ID of the room to fetch status for  
- **Response**:  
  ```json
  {
    "temperature": 22.5,
    "humidity": 45,
    "harmfulGases": "Low"
  }
