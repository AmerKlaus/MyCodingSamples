import 'package:flutter/material.dart';
import 'globals.dart' as globals;

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Pizza App',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      initialRoute: '/',
      routes: {
        '/': (context) => MainPage(),
        '/register': (context) => RegisterPage(),
        '/home': (context) => HomePage(),
        '/pizza_details': (context) => PizzaDetailsPage(pizzaIndex: 0,),
        '/order_summary': (context) => OrderSummaryPage(totalPrice: 0,),
      },
    );
  }
}

class MainPage extends StatelessWidget {
  final TextEditingController _userIDController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  void _login(BuildContext context) {
    String userID = _userIDController.text;
    String password = _passwordController.text;

    // Check if user ID or password is empty
    if (userID.isEmpty || password.isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Please enter User ID and Password.'),
        ),
      );
      return;
    }

    // Check user credentials against registered data
    bool isValidCredentials = _checkCredentials(userID, password);

    if (isValidCredentials) {
      Navigator.pushReplacement(
        context,
        MaterialPageRoute(builder: (context) => HomePage()),
      );
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Invalid credentials. Please try again.'),
        ),
      );
    }
  }

  bool _checkCredentials(String userID, String password) {
    // Replace this with your logic to check if credentials match those in the register page
    return (userID == globals.globalUserID && password == globals.globalPassword);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Pizza App'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            TextField(
              controller: _userIDController,
              decoration: InputDecoration(
                labelText: 'User ID',
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(20.0),
                ),
              ),
            ),
            SizedBox(height: 20),
            TextField(
              controller: _passwordController,
              obscureText: true,
              decoration: InputDecoration(
                labelText: 'Password',
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(20.0),
                ),
              ),
            ),
            SizedBox(height: 20),
            SizedBox(
              width: double.infinity,
              child: ElevatedButton(
                onPressed: () => _login(context),
                child: Text('Login'),
                style: ElevatedButton.styleFrom(
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(20.0),
                  ),
                ),
              ),
            ),
            SizedBox(height: 10),
            SizedBox(
              width: double.infinity,
              child: TextButton(
                onPressed: () {
                  Navigator.pushNamed(context, '/register');
                },
                child: Text('Register'),
              ),
            ),
          ],
        ),
      ),
    );
  }
}

class RegisterPage extends StatefulWidget {
  @override
  _RegisterPageState createState() => _RegisterPageState();
}

class _RegisterPageState extends State<RegisterPage> {
  final TextEditingController _userIDController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _confirmPasswordController = TextEditingController();

  void _saveRegistration(BuildContext context) {
    String userID = _userIDController.text;
    String password = _passwordController.text;
    String confirmPassword = _confirmPasswordController.text;

    // Validate user input
    if (userID.isEmpty || password.isEmpty || confirmPassword.isEmpty) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Please fill in all fields.'),
        ),
      );
      return;
    }

    if (password != confirmPassword) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Passwords do not match.'),
        ),
      );
      return;
    }

    // Set global variables
    globals.globalUserID = userID;
    globals.globalPassword = password;

    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        content: Text('Registration successful'),
      ),
    );

    // Optionally navigate to the login page or home page
    Navigator.pushReplacementNamed(context, '/');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Register'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            TextField(
              controller: _userIDController,
              decoration: InputDecoration(
                labelText: 'User ID',
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(20.0),
                ),
              ),
            ),
            SizedBox(height: 20),
            TextField(
              controller: _passwordController,
              obscureText: true,
              decoration: InputDecoration(
                labelText: 'Password',
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(20.0),
                ),
              ),
            ),
            SizedBox(height: 20),
            TextField(
              controller: _confirmPasswordController,
              obscureText: true,
              decoration: InputDecoration(
                labelText: 'Confirm Password',
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(20.0),
                ),
              ),
            ),
            SizedBox(height: 20),
            SizedBox(
              width: double.infinity,
              child: ElevatedButton(
                onPressed: () => _saveRegistration(context),
                child: Text('Save'),
                style: ElevatedButton.styleFrom(
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(20.0),
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Home'),
        actions: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Text(
              'Welcome ${globals.globalUserID ?? ''}',
              style: TextStyle(fontSize: 16),
            ),
          ),
        ],
      ),
      body: GridView.count(
        crossAxisCount: 2,
        padding: EdgeInsets.all(16.0),
        children: List.generate(
          4,
              (index) => GestureDetector(
            onTap: () {
              Navigator.push(
                context,
                MaterialPageRoute(builder: (context) => PizzaDetailsPage(pizzaIndex: index)),
              );
            },
            child: Card(
              elevation: 4.0,
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Image.asset(
                    'assets/pizza$index.png',
                    height: 100,
                    width: 100,
                    fit: BoxFit.cover,
                  ),
                  SizedBox(height: 8.0),
                  Text('Pizza $index'),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}

class PizzaDetailsPage extends StatefulWidget {
  final int pizzaIndex;

  const PizzaDetailsPage({Key? key, required this.pizzaIndex}) : super(key: key);

  @override
  _PizzaDetailsPageState createState() => _PizzaDetailsPageState();
}

class _PizzaDetailsPageState extends State<PizzaDetailsPage> {
  int _quantity = 1; // Initial quantity
  String _selectedSize = 'small'; // Initial size selection
  List<String> _selectedToppings = []; // Initial toppings selection

  // Prices for different sizes and toppings
  Map<String, double> _sizePrices = {
    'small': 10.0,
    'medium': 20.0,
    'big': 30.0,
  };
  Map<String, double> _toppingPrices = {
    'small': 2.0,
    'medium': 3.0,
    'big': 5.0,
  };

  // Calculate total cost based on quantity, size, and toppings
  double _calculateTotalCost() {
    double sizePrice = _sizePrices[_selectedSize] ?? 0.0;
    double toppingsPrice = _selectedToppings.length * _toppingPrices[_selectedSize]!;
    return (sizePrice + toppingsPrice) * _quantity;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Pizza Details'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              'Pizza ${widget.pizzaIndex}',
              style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 16.0),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text('User ID: ${globals.globalUserID ?? ''}'),
                Text('Price: ${_calculateTotalCost().toStringAsFixed(2)} CAD'),
              ],
            ),
            SizedBox(height: 16.0),
            Center(
              child: Image.asset(
                'assets/pizza${widget.pizzaIndex}.png',
                height: 200,
                width: 200,
                fit: BoxFit.cover,
              ),
            ),
            SizedBox(height: 16.0),
            Text(
              'Description: This is a delicious pizza with various toppings.',
              style: TextStyle(fontSize: 16),
            ),
            SizedBox(height: 16.0),
            Text(
              'Size:',
              style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
            ),
            Row(
              children: _sizePrices.keys.map((size) {
                return Row(
                  children: [
                    Radio(
                      value: size,
                      groupValue: _selectedSize,
                      onChanged: (value) {
                        setState(() {
                          _selectedSize = value.toString();
                        });
                      },
                    ),
                    Text(size),
                  ],
                );
              }).toList(),
            ),
            SizedBox(height: 16.0),
            Text(
              'Toppings:',
              style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
            ),
            Row(
              children: _sizePrices.keys.map((size) {
                return Row(
                  children: [
                    Checkbox(
                      value: _selectedToppings.contains(size),
                      onChanged: (value) {
                        setState(() {
                          if (value != null && value) {
                            _selectedToppings.add(size);
                          } else {
                            _selectedToppings.remove(size);
                          }
                        });
                      },
                    ),
                    Text('$size (${_toppingPrices[size]} CAD)'),
                  ],
                );
              }).toList(),
            ),
            SizedBox(height: 16.0),
            Text(
              'Quantity:',
              style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
            ),
            Row(
              children: [
                IconButton(
                  onPressed: () {
                    setState(() {
                      if (_quantity > 1) {
                        _quantity--;
                      }
                    });
                  },
                  icon: Icon(Icons.remove),
                ),
                Text('$_quantity'),
                IconButton(
                  onPressed: () {
                    setState(() {
                      _quantity++;
                    });
                  },
                  icon: Icon(Icons.add),
                ),
              ],
            ),
            SizedBox(height: 16.0),
            Text(
              'Total Cost: ${_calculateTotalCost().toStringAsFixed(2)} CAD',
              style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 32.0),
            ElevatedButton(
              onPressed: () {
                // Calculate the total cost
                double totalPrice = _calculateTotalCost();

                // Navigate to the order summary page
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => OrderSummaryPage(totalPrice: totalPrice),
                  ),
                );
              },
              child: Text('Order'),
            ),
          ],
        ),
      ),
    );
  }
}

class OrderSummaryPage extends StatelessWidget {
  final double totalPrice;

  const OrderSummaryPage({Key? key, required this.totalPrice}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Order Summary'),
        actions: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Text(
              'User ID: ${globals.globalUserID ?? ''}',
              style: TextStyle(fontSize: 16),
            ),
          ),
        ],
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text(
              'Total Price: ${totalPrice.toStringAsFixed(2)} CAD',
              style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 32.0),
            ElevatedButton(
              onPressed: () {
                // Navigate back to the home page
                Navigator.popUntil(context, ModalRoute.withName('/'));
              },
              child: Text('Home'),
            ),
          ],
        ),
      ),
    );
  }
}
