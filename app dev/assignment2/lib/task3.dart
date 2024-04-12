import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Weather App',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: WeatherScreen(),
    );
  }
}

class WeatherScreen extends StatefulWidget {
  @override
  _WeatherScreenState createState() => _WeatherScreenState();
}

class _WeatherScreenState extends State<WeatherScreen> {
  final String apiKey = '46af5cd512440fae86aa46276512a7f2';
  final String baseUrl = 'http://api.weatherstack.com/current';
  String location = 'Montreal';
  String temperature = '';
  String weatherIcon = '';
  String weatherDescription = '';
  String windSpeed = '';
  String precipitation = '';
  String cloudPercentage = '';
  String cityName = '';
  List<HourlyForecast> hourlyForecasts = [];

  @override
  void initState() {
    super.initState();
    fetchWeather();
  }

  Future<void> fetchWeather() async {
    final Uri uri = Uri(
      scheme: 'http',
      host: 'api.weatherstack.com',
      path: '/forecast',
      queryParameters: {
        'access_key': apiKey,
        'query': location,
      },
    );

    final response = await http.get(uri);
    final decodedResponse = json.decode(response.body);

    setState(() {
      temperature = decodedResponse['current']['temperature'].toString();
      weatherIcon = decodedResponse['current']['weather_icons'][0];
      weatherDescription =
      decodedResponse['current']['weather_descriptions'][0];
      windSpeed = decodedResponse['current']['wind_speed'].toString();
      precipitation = decodedResponse['current']['precip'].toString();
      cloudPercentage = decodedResponse['current']['cloudcover'].toString();
      cityName = decodedResponse['location']['name'];

      if (decodedResponse['forecast'] != null &&
          decodedResponse['forecast']['hourly'] != null) {
        hourlyForecasts.clear();
        for (var forecast in decodedResponse['forecast']['hourly']) {
          hourlyForecasts.add(HourlyForecast.fromJson(forecast));
        }
      }
    });
  }

  void changeLocation(String newLocation) {
    setState(() {
      location = newLocation;
      fetchWeather();
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Weather App'),
      ),
      body: SingleChildScrollView(
        padding: EdgeInsets.all(20),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: <Widget>[
            Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: <Widget>[
                TextButton(
                  onPressed: () => changeLocation('Montreal'),
                  child: Text(
                    'Montreal',
                    style: TextStyle(fontSize: 16),
                  ),
                ),
                TextButton(
                  onPressed: () => changeLocation('Mumbai'),
                  child: Text(
                    'Mumbai',
                    style: TextStyle(fontSize: 16),
                  ),
                ),
                TextButton(
                  onPressed: () => changeLocation('New York'),
                  child: Text(
                    'New York',
                    style: TextStyle(fontSize: 16),
                  ),
                ),
              ],
            ),
            SizedBox(height: 20),
            Image.network(
              weatherIcon,
              width: 100,
              height: 100,
            ),
            SizedBox(height: 10),
            Text(
              '$temperature°C',
              style: TextStyle(fontSize: 36),
            ),
            Text(
              weatherDescription,
              style: TextStyle(fontSize: 24),
            ),
            Text(
              cityName,
              style: TextStyle(fontSize: 18),
            ),
            SizedBox(height: 20),
            Divider(),
            SizedBox(height: 20),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: <Widget>[
                _buildWeatherInfoItem('Wind', '$windSpeed km/h', Icons.toys),
                _buildWeatherInfoItem(
                    'Precipitation', '$precipitation mm', Icons.grain),
                _buildWeatherInfoItem(
                    'Cloud', '$cloudPercentage%', Icons.cloud),
              ],
            ),
            SizedBox(height: 20),
            Divider(),
            SizedBox(height: 20),
            Text(
              'Hourly Forecast:',
              style: TextStyle(fontSize: 24),
            ),
            SizedBox(height: 10),
            Container(
              height: 120,
              child: ListView.builder(
                scrollDirection: Axis.horizontal,
                itemCount: hourlyForecasts.length,
                itemBuilder: (context, index) {
                  return _buildHourlyForecastCard(hourlyForecasts[index]);
                },
              ),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildWeatherInfoItem(String title, String value, IconData iconData) {
    return Column(
      children: <Widget>[
        Icon(iconData, size: 40),
        SizedBox(height: 5),
        Text(
          title,
          style: TextStyle(fontSize: 18),
        ),
        Text(
          value,
          style: TextStyle(fontSize: 16),
        ),
      ],
    );
  }

  Widget _buildHourlyForecastCard(HourlyForecast forecast) {
    return Container(
      width: 100,
      margin: EdgeInsets.symmetric(horizontal: 8),
      decoration: BoxDecoration(
        border: Border.all(color: Colors.grey),
        borderRadius: BorderRadius.circular(10),
      ),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: <Widget>[
          Text(
            forecast.time,
            style: TextStyle(fontSize: 16),
          ),
          SizedBox(height: 5),
          Image.network(
            forecast.weatherIcon,
            width: 40,
            height: 40,
          ),
          SizedBox(height: 5),
          Text(
            forecast.temperature,
            style: TextStyle(fontSize: 16),
          ),
        ],
      ),
    );
  }
}

class HourlyForecast {
  final String time;
  final String temperature;
  final String weatherIcon;

  HourlyForecast({
    required this.time,
    required this.temperature,
    required this.weatherIcon,
  });

  factory HourlyForecast.fromJson(Map<String, dynamic> json) {
    return HourlyForecast(
      time: json['time'],
      temperature: '${json['temperature']}°C',
      weatherIcon: json['weather_icon'][0],
    );
  }
}