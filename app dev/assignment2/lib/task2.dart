import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:cached_network_image/cached_network_image.dart';
import 'package:table_calendar/table_calendar.dart';
import 'package:intl/intl.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Side Navigation Bar',
      theme: ThemeData(
        primaryColor: Colors.deepPurple,
        visualDensity: VisualDensity.adaptivePlatformDensity,
      ),
      home: MyHomePage(),
      routes: {
        '/settings': (context) => SettingsUI(),
        '/calendar': (context) => CalendarPage(),
      },
    );
  }
}

class MyHomePage extends StatefulWidget {
  @override
  _MyHomePageState createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  int _selectedIndex = 0;

  void _onItemTapped(int index) {
    setState(() {
      _selectedIndex = index;
    });
    Navigator.of(context).pop();

    if (_selectedIndex == 1) {
      Navigator.pushNamed(context, '/calendar');
    } else if (_selectedIndex == 2) {
      Navigator.pushNamed(context, '/settings');
    } else if (_selectedIndex == 3) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Logging out...'),
        ),
      );
      Navigator.popUntil(context, ModalRoute.withName('/'));
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Side Navigation Bar Task'),
      ),
      drawer: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: <Widget>[
            DrawerHeader(
              child: Image.asset(
                'assets/FlutterLogo.png',
                width: 100,
                height: 100,
              ),
              decoration: BoxDecoration(
                color: Colors.deepPurple,
              ),
            ),
            ListTile(
              leading: Icon(Icons.person),
              title: Text('Profile'),
              onTap: () {
                _onItemTapped(0);
              },
            ),
            ListTile(
              leading: Icon(Icons.notifications),
              title: Text('Notifications'),
              onTap: () {
                _onItemTapped(1);
              },
            ),
            ListTile(
              leading: Icon(Icons.settings),
              title: Text('Settings'),
              onTap: () {
                _onItemTapped(2);
              },
            ),
            ListTile(
              leading: Icon(Icons.exit_to_app),
              title: Text('Logout'),
              onTap: () {
                _onItemTapped(3);
              },
            ),
          ],
        ),
      ),
      body: Center(
        child: _selectedIndex == 0
            ? ProfileScreen()
            : Text(
          'Navigation App\n'
              'This navigation app allows users to fetch JSON data, view calendar events, access settings, and log out.',
          textAlign: TextAlign.center,
          style: TextStyle(fontWeight: FontWeight.bold),
        ),
      ),
    );
  }
}

class ProfileScreen extends StatefulWidget {
  @override
  _ProfileScreenState createState() => _ProfileScreenState();
}

class _ProfileScreenState extends State<ProfileScreen> {
  List<dynamic> _data = [];

  @override
  void initState() {
    super.initState();
    _fetchData();
  }

  Future<void> _fetchData() async {
    final response = await http
        .get(Uri.parse('https://jsonplaceholder.typicode.com/photos'));
    if (response.statusCode == 200) {
      setState(() {
        _data = json.decode(response.body);
      });
    } else {
      throw Exception('Failed to load data');
    }
  }

  @override
  Widget build(BuildContext context) {
    return _data.isEmpty
        ? Center(
      child: CircularProgressIndicator(),
    )
        : ListView.builder(
      itemCount: _data.length,
      itemBuilder: (context, index) {
        final item = _data[index];
        return ListTile(
          leading: SizedBox(
            width: 56,
            child: CachedNetworkImage(
              imageUrl: item['thumbnailUrl'],
              placeholder: (context, url) => CircularProgressIndicator(),
              errorWidget: (context, url, error) => Icon(Icons.error),
            ),
          ),
          title: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(item['title']),
              Text('ID: ${item['id']}'),
            ],
          ),
          subtitle: Text('Album ID: ${item['albumId']}'),
          trailing: SizedBox(
            width: 100,
            child: CachedNetworkImage(
              imageUrl: item['url'],
              placeholder: (context, url) => CircularProgressIndicator(),
              errorWidget: (context, url, error) => Icon(Icons.error),
            ),
          ),
          onTap: () {
            // Handle item tap if needed
          },
        );
      },
    );
  }
}

class CalendarPage extends StatefulWidget {
  @override
  _CalendarPageState createState() => _CalendarPageState();
}

class _CalendarPageState extends State<CalendarPage> {
  CalendarFormat _calendarFormat = CalendarFormat.month;
  DateTime _focusedDay = DateTime.now();
  DateTime _selectedDay = DateTime.now(); // Added for tracking selected day

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Calendar'),
      ),
      body: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          Text(
            _focusedDay.year.toString(),
            style: TextStyle(fontWeight: FontWeight.bold, fontSize: 24),
          ),
          SizedBox(height: 8),
          Text(
            DateFormat('EEE, MMM dd').format(_focusedDay),
            style: TextStyle(fontSize: 18),
          ),
          SizedBox(height: 16),
          TableCalendar(
            firstDay: DateTime.utc(2020, 1, 1),
            lastDay: DateTime.utc(2030, 12, 31),
            focusedDay: _focusedDay,
            selectedDayPredicate: (day) {
              return isSameDay(_selectedDay, day); // Highlight selected day
            },
            calendarFormat: _calendarFormat,
            onFormatChanged: (format) {
              setState(() {
                _calendarFormat = format;
              });
            },
            onDaySelected: (selectedDay, focusedDay) {
              setState(() {
                _selectedDay = selectedDay; // Update selected day
                _focusedDay = focusedDay;
              });
            },
          ),
          SizedBox(height: 16),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              ElevatedButton(
                onPressed: () {
                  Navigator.pop(context);
                },
                child: Text('Cancel'),
              ),
              ElevatedButton(
                onPressed: () {
                  print('Selected date: $_selectedDay');
                  Navigator.of(context).pop();
                },
                child: Text('OK'),
              ),
            ],
          ),
        ],
      ),
    );
  }
}

class SettingsUI extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Settings UI'),
      ),
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            ListTile(
              title: Text(
                'Common',
                style: TextStyle(color: Colors.deepOrange),
              ),
            ),
            ListTile(
              title: Row(
                children: [
                  Icon(Icons.language),
                  SizedBox(width: 8),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text('Language'),
                      Text(
                        'English',
                        style: TextStyle(color: Colors.black),
                      ),
                    ],
                  ),
                ],
              ),
            ),
            Divider(),
            ListTile(
              title: Row(
                children: [
                  Icon(Icons.cloud),
                  SizedBox(width: 8),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text('Environment'),
                      Text(
                        'Production',
                        style: TextStyle(color: Colors.black),
                      ),
                    ],
                  ),
                ],
              ),
            ),
            Divider(),
            ListTile(
              title: Text(
                'Account',
                style: TextStyle(color: Colors.deepOrange),
              ),
            ),
            ListTile(
              leading: Icon(Icons.phone),
              title: Text('Phone Number'),
            ),
            Divider(),
            ListTile(
              leading: Icon(Icons.email),
              title: Text('Email'),
            ),
            Divider(),
            ListTile(
              leading: Icon(Icons.exit_to_app),
              title: Text('Sign Out'),
            ),
            ListTile(
              title: Text(
                'Security',
                style: TextStyle(color: Colors.deepOrange),
              ),
            ),
            ListTile(
              leading: Icon(Icons.lock),
              title: Text('Lock App in Background'),
              trailing: Switch(
                value: true,
                onChanged: (value) {},
                activeColor: Colors.deepOrange,
              ),
            ),
          ],
        ),
      ),
    );
  }
}