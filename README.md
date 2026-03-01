# BOOKING SYSTEM API

The API can be tested using **Swagger UI** or **Postman**

Authentication is required for all endpoints except **Login**

You must first log in to obtain a JWT token

For demonstration purposes, authentication uses a predefined in-memory list of users instead of a database

---

## Available Test Users

```
Username: petkop
Password: P@ssw0rd
```

```
Username: trajkot
Password: Test123!
```

In a production environment, users would be stored securely in a persistent data store with hashed passwords

---

## 1. LOGIN

### Endpoint

```
POST /api/auth/login
```

### Request Body

```json
{
  "username": "petkop",
  "password": "P@ssw0rd"
}
```

### Response

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

---

## HOW TO USE THE TOKEN

### Swagger

1. Click the **Authorize** button (top right)
2. Paste only the JWT token (without Bearer)
3. Click **Authorize**

### Postman

1. Go to the **Authorization** tab
2. Select **Bearer Token**
3. Paste the token into the Token field

---

## 2. SEARCH

### Endpoint

```
POST /api/search
```

### Authorization

```
Authorization: Bearer {token}
```

---

### Hotel Only Example

#### Request Body

```json
{
  "destination": "SKP",
  "departureAirport": "",
  "fromDate": "2026-06-01T13:19:46.755Z",
  "toDate": "2026-06-02T13:19:46.755Z"
}
```

---

### Hotel + Flight Example

#### Request Body

```json
{
  "destination": "SKP",
  "departureAirport": "OSL",
  "fromDate": "2026-06-01T13:19:46.755Z",
  "toDate": "2026-06-02T13:19:46.755Z"
}
```

---

### Last Minute Example

#### Request Body

```json
{
  "destination": "SKP",
  "departureAirport": "",
  "fromDate": "2026-04-01T13:19:46.755Z",
  "toDate": "2026-04-02T13:19:46.755Z"
}
```

---

### Example Response

If no departure airport is provided, the `flightCode` will be `null` (hotel-only search)

```json
{
  "options": [
    {
      "optionCode": "ABC123",
      "hotelCode": "8626",
      "flightCode": "461",
      "arrivalAirport": "SKP",
      "price": 120
    }
  ]
}
```

---

## 3. BOOK

### Endpoint

```
POST /api/booking/book
```

### Authorization

```
Authorization: Bearer {token}
```

### Request Body

```json
{
  "optionCode": "ABC123"
}
```

### Response

```json
{
  "bookingCode": "A1B2C3",
  "bookingTime": "2026-02-28T12:00:00Z"
}
```

---

## 4. CHECK STATUS

### Endpoint

```
GET /api/booking/status/A1B2C3
```

### Authorization

```
Authorization: Bearer {token}
```

---

## Possible Status Values

| Value | Meaning |
| ----- | ------- |
| 0     | Pending |
| 1     | Success |
| 2     | Failed  |

---

### a) While Sleep Time Has Not Elapsed

```json
{
  "status": 0
}
```

---

### b) After Sleep Time Elapses (Non-Last-Minute Booking)

```json
{
  "status": 1
}
```

---

### c) After Sleep Time Elapses (Last Minute Booking)

```json
{
  "status": 2
}
```

---

## NOTES

* Login must be performed before accessing protected endpoints
* The JWT token must be included in the Authorization header
* Status changes from Pending to Success or Failed after the configured sleep time
* LastMinuteHotels bookings will result in **Failed** status after processing

---
