import 'package:flutter/material.dart';

void main() {
  runApp(MaterialApp(
    home: HotelBookingPage(),
  ));
}

class HotelBookingPage extends StatefulWidget {
  @override
  _HotelBookingPageState createState() => _HotelBookingPageState();
}

class _HotelBookingPageState extends State<HotelBookingPage> {
  int numberOfGuests = 1;
  int numberOfRooms = 1;

  void incrementGuests() {
    setState(() {
      numberOfGuests++;
    });
  }

  void decrementGuests() {
    setState(() {
      if (numberOfGuests > 1) {
        numberOfGuests--;
      }
    });
  }

  void incrementRooms() {
    setState(() {
      numberOfRooms++;
    });
  }

  void decrementRooms() {
    setState(() {
      if (numberOfRooms > 1) {
        numberOfRooms--;
      }
    });
  }

  void reserve() {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        content: Text('You are trying to book $numberOfGuests guests and $numberOfRooms rooms'),
      ),
    );
  }

  void bookHotels() {
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) => ConfirmationPage(
          numberOfGuests: numberOfGuests,
          numberOfRooms: numberOfRooms,
        ),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Hotel Booking'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Row(
              children: [
                Icon(Icons.location_on),
                Text('Location'),
                Icon(Icons.arrow_forward_ios, color: Colors.grey),
              ],
            ),
            SizedBox(height: 20),
            Row(
              children: [
                Icon(Icons.person),
                IconButton(
                  icon: Icon(Icons.remove),
                  onPressed: decrementGuests,
                ),
                Text('$numberOfGuests'),
                IconButton(
                  icon: Icon(Icons.add),
                  onPressed: incrementGuests,
                ),
              ],
            ),
            SizedBox(height: 20),
            Row(
              children: [
                Icon(Icons.hotel),
                IconButton(
                  icon: Icon(Icons.remove),
                  onPressed: decrementRooms,
                ),
                Text('$numberOfRooms'),
                IconButton(
                  icon: Icon(Icons.add),
                  onPressed: incrementRooms,
                ),
              ],
            ),
            SizedBox(height: 20),
            Row(
              children: [
                Icon(Icons.arrow_forward, color: Colors.black,),
                Text('Today'),
                Icon(Icons.arrow_forward_ios, color: Colors.grey),
              ],
            ),
            SizedBox(height: 20),
            Row(
              children: [
                Icon(Icons.arrow_back, color: Colors.black,),
                Text('Tomorrow'),
                Icon(Icons.arrow_forward_ios, color: Colors.grey),
              ],
            ),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: reserve,
              child: Text('Reserve'),
              style: ButtonStyle(
                backgroundColor: MaterialStateProperty.all<Color>(Colors.orange),
              ),
            ),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: bookHotels,
              child: Text('Book Hotels'),
              style: ButtonStyle(
                backgroundColor: MaterialStateProperty.all<Color>(Colors.orange),
              ),
            ),
          ],
        ),
      ),
    );
  }
}

class ConfirmationPage extends StatelessWidget {
  final int numberOfGuests;
  final int numberOfRooms;

  ConfirmationPage({required this.numberOfGuests, required this.numberOfRooms});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Confirmation'),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text('Booking confirmed for:'),
            SizedBox(height: 20),
            Text('$numberOfGuests guests'),
            SizedBox(height: 10),
            Text('$numberOfRooms rooms'),
          ],
        ),
      ),
    );
  }
}
