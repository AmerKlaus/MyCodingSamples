import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:firebase_core/firebase_core.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:firebase_storage/firebase_storage.dart';
import 'package:flutter/gestures.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'dart:math';
import 'dart:io';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:url_launcher/url_launcher.dart';
import 'package:image_picker/image_picker.dart';

//class to set the theme either light or dark
class ThemeProvider with ChangeNotifier {

  //the default theme is light
  ThemeData _currentTheme = ThemeData.light();

  //while dark mode is set to false
  bool _isDarkMode = false;

  //determine what the theme is
  ThemeData getCurrentTheme() => _currentTheme;

  bool get isDarkMode => _isDarkMode;

  //change theme depending on the toggle of the switch
  void toggleTheme() {
    _isDarkMode = !_isDarkMode;
    _currentTheme = _isDarkMode ? ThemeData.dark() : ThemeData.light();

    //let the listener know when the theme changes
    notifyListeners();
  }
}

//main method (initialize firebase here include the theme through the whole
// application)
void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await Firebase.initializeApp();
  runApp(
    ChangeNotifierProvider(
      create: (context) => ThemeProvider(),
      child: MyApp(),
    ),
  );
}

//provide the theme here as well
//determine if light or dark
class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var themeProvider = Provider.of<ThemeProvider>(context);
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Bibliotech',
      theme: themeProvider.getCurrentTheme(),
      home: LoginPage(),
      // Customize the icon theme
      themeMode: themeProvider.isDarkMode ? ThemeMode.dark : ThemeMode.light,
      darkTheme: ThemeData.dark().copyWith(
        // Customize the icon theme for dark mode
        //if dark they are white if light they are dark
        iconTheme: IconThemeData(color: Colors.white),
      ),
    );
  }
}
//default home page
class MyHomePage extends StatefulWidget {
  @override
  _MyHomePageState createState() => _MyHomePageState();
}

//keep track of the index for the nav bar
class _MyHomePageState extends State<MyHomePage> {
  int _currentIndex = 0; // Index 1 for Book List

  final List<Widget> _pages = [
    HomePage(), // Index 0 for Home
    BookListPage(), // Index 1 for Book List
    LibraryPage(), // Index 2 for Library
    ProfilePage(), // Index 3 Profile page
    SettingsPage(), // Index 4 Settings page
    EventPage(), // Index 5 Event Page
    CommunityPage(), // Index 6 Community Page
  ];

  //making it so once a index(icon) is tapped that index will load
  void _onItemTapped(int index) {
    setState(() {
      _currentIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Bibliotech'),
      ),
      body: _pages[_currentIndex],
      bottomNavigationBar: MyNavigationBar(
        currentIndex: _currentIndex,
        onItemTapped: _onItemTapped,
      ),
    );
  }
}

//navigation bar class
class MyNavigationBar extends StatelessWidget {
  final int currentIndex;
  final Function(int) onItemTapped;

  //both require the current index and the tap action by the user
  MyNavigationBar({required this.currentIndex, required this.onItemTapped});

  //all icons for the bottom navigation bar
  @override
  Widget build(BuildContext context) {
    var themeProvider = Provider.of<ThemeProvider>(context);
    Color iconColor = themeProvider.isDarkMode ? Colors.white : Colors.black;

    return BottomNavigationBar(
      type: BottomNavigationBarType.fixed,
      currentIndex: currentIndex,
      onTap: onItemTapped,
      items: [
        BottomNavigationBarItem(
          icon: Icon(Icons.home, color: iconColor),
          label: 'Home',
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.book, color: iconColor),
          label: 'Books',
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.library_books, color: iconColor),
          label: 'Library',
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.person, color: iconColor),
          label: 'Profile',
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.settings, color: iconColor),
          label: 'Settings',
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.event, color: iconColor),
          label: 'Events',
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.people, color: iconColor),
          label: 'Community',
        ),
      ],

      // Ensure the navigation bar is visible in both light and dark modes
      backgroundColor:
          themeProvider.isDarkMode ? Colors.grey[900] : Colors.white,

      // Set the elevation to avoid blending with the background color
      elevation: 8.0,
    );
  }
}

//real homepage that displays library news
class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var themeProvider = Provider.of<ThemeProvider>(context);

    return Scaffold(
      appBar: AppBar(
        title: Text('Home'),
      ),
      body: ListView(
        padding: EdgeInsets.all(16.0),
        children: [
          // Latest News Section
          Container(
            padding: EdgeInsets.all(12.0),
            decoration: BoxDecoration(
              color: themeProvider.isDarkMode
                  ? Colors.grey[800]
                  : Colors.grey[200],
              borderRadius: BorderRadius.circular(8.0),
            ),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  'Latest News',
                  style: TextStyle(
                      fontSize: 20,
                      fontWeight: FontWeight.bold,
                      color: themeProvider.isDarkMode
                          ? Colors.white
                          : Colors.black),
                ),
                SizedBox(height: 12.0),
                _buildNewsItem(
                  'New Library Events Announced!',
                  'Discover exciting upcoming events at our library, from author talks to book clubs and more. Stay tuned for dates and details!',
                  themeProvider,
                ),
                SizedBox(height: 8.0),
                _buildNewsItem(
                  'Library Expansion Update',
                  "Get the latest on our library's expansion project, including new sections, enhanced facilities, and a broader collection of books and resources.",
                  themeProvider,
                ),
                SizedBox(height: 8.0),
                _buildNewsItem(
                  'Digital Library Access Now Available!',
                  "Access our library's digital collection from anywhere, anytime. Explore e-books, audiobooks, and digital resources to enrich your reading experience.",
                  themeProvider,
                ),
              ],
            ),
          ),
          SizedBox(height: 24.0),
          // Logout Option
          ElevatedButton(
            onPressed: () {
              Navigator.pushReplacement(
                context,
                MaterialPageRoute(builder: (context) => LoginPage()),
              );
            },
            child: Text(
              'Logout',
              style: TextStyle(
                  color:
                      themeProvider.isDarkMode ? Colors.white : Colors.black),
            ),
            style: ElevatedButton.styleFrom(
              padding: EdgeInsets.symmetric(vertical: 12.0),
              textStyle: TextStyle(fontSize: 16),
            ),
          ),
        ],
      ),
    );
  }

  //more options for light and dark reading visibility
  Widget _buildNewsItem(
      String title, String description, ThemeProvider themeProvider) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          title,
          style: TextStyle(
              fontSize: 16,
              fontWeight: FontWeight.bold,
              color: themeProvider.isDarkMode ? Colors.white : Colors.black),
        ),
        SizedBox(height: 4.0),
        Text(description,
            style: TextStyle(
                color: themeProvider.isDarkMode ? Colors.white : Colors.black)),
        Divider(),
      ],
    );
  }
}

Widget _buildNewsItem(String title, String description) {
  return Column(
    crossAxisAlignment: CrossAxisAlignment.start,
    children: [
      Text(
        title,
        style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
      ),
      SizedBox(height: 4.0),
      Text(description),
      Divider(),
    ],
  );
}

//register page
class RegisterPage extends StatefulWidget {
  @override
  _RegisterPageState createState() => _RegisterPageState();
}

//asking user for their input (added option to hide and unhide password)
class _RegisterPageState extends State<RegisterPage> {
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  final TextEditingController _confirmPasswordController =
      TextEditingController();
  bool _obscurePassword = true;

  //regular expression to require user for a strong password
  bool _isStrongPassword(String password) {
    String pattern =
        r'^(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[!@#$%^&*()_+{}|:"<>?~]).{8,}$';
    RegExp regExp = RegExp(pattern);
    return regExp.hasMatch(password);
  }

  //determining if the email is a valid one (includes a @ or not)
  bool _isValidEmail(String email) {
    String pattern = r'^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$';
    RegExp regExp = RegExp(pattern);
    return regExp.hasMatch(email);
  }

  //method to register (both password should match)
  //if not throw an error
  Future<void> _registerWithEmailAndPassword(BuildContext context) async {
    if (_passwordController.text != _confirmPasswordController.text) {
      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          title: Text('Error'),
          content: Text('Passwords do not match.'),
          actions: [
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: Text('OK'),
            ),
          ],
        ),
      );
      return;
    }

    //if the password is not strong enough
    //throw an error and let the user try again
    if (!_isStrongPassword(_passwordController.text)) {
      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          title: Text('Error'),
          content: Text(
              'Password is not strong enough. It must be at least 8 characters long and contain a mix of letters, numbers, symbols, and at least one uppercase letter.'),
          actions: [
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: Text('OK'),
            ),
          ],
        ),
      );
      return;
    }

    //if email is not valid
    //throw an error and let the user try again
    if (!_isValidEmail(_emailController.text)) {
      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          title: Text('Error'),
          content: Text('Invalid email format.'),
          actions: [
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: Text('OK'),
            ),
          ],
        ),
      );
      return;
    }

    //database operation of verifying
    try {
      UserCredential userCredential =
          await FirebaseAuth.instance.createUserWithEmailAndPassword(
        email: _emailController.text,
        password: _passwordController.text,
      );

      //database operation of storing the newly acquired information
      //from the user
      await FirebaseFirestore.instance
          .collection('Users')
          .doc(userCredential.user!.uid)
          .set({
        'userId': userCredential.user!.uid,
        'email': _emailController.text,
      });

      //after register user goes back to login
      //if reigster fails throw error and let user try again
      Navigator.pushReplacement(
        context,
        MaterialPageRoute(builder: (context) => LoginPage()),
      );
    } catch (e) {
      print('Failed to register: $e');
      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          title: Text('Error'),
          content: Text('Failed to register. Please try again.'),
          actions: [
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: Text('OK'),
            ),
          ],
        ),
      );
    }
  }

  //the actual register form
  //has icon to hide and unhide password
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Bibliotech'),
        centerTitle: true,
      ),
      body: SingleChildScrollView(
        padding: EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text(
              'Bibliotech',
              style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 16.0),
            Text(
              'Create Account',
              style: TextStyle(fontSize: 20),
            ),
            SizedBox(height: 8.0),
            Text(
              'Let\'s get started by filling out the form below.',
              style: TextStyle(fontSize: 16),
            ),
            SizedBox(height: 16.0),
            TextField(
              controller: _emailController,
              decoration: InputDecoration(
                labelText: 'Email',
                border: OutlineInputBorder(),
              ),
              keyboardType: TextInputType.emailAddress,
            ),
            SizedBox(height: 16.0),
            TextField(
              controller: _passwordController,
              decoration: InputDecoration(
                labelText: 'Password',
                border: OutlineInputBorder(),
                suffixIcon: IconButton(
                  icon: Icon(_obscurePassword
                      ? Icons.visibility_off
                      : Icons.visibility),
                  onPressed: () {
                    setState(() {
                      _obscurePassword = !_obscurePassword;
                    });
                  },
                ),
              ),
              obscureText: _obscurePassword,
            ),
            SizedBox(height: 16.0),
            TextField(
              controller: _confirmPasswordController,
              decoration: InputDecoration(
                labelText: 'Confirm Password',
                border: OutlineInputBorder(),
                suffixIcon: IconButton(
                  icon: Icon(_obscurePassword
                      ? Icons.visibility_off
                      : Icons.visibility),
                  onPressed: () {
                    setState(() {
                      _obscurePassword = !_obscurePassword;
                    });
                  },
                ),
              ),
              obscureText: _obscurePassword,
            ),
            SizedBox(height: 24.0),
            ElevatedButton(
              onPressed: () => _registerWithEmailAndPassword(context),
              child: Text('Register'),
              style: ElevatedButton.styleFrom(
                padding: EdgeInsets.symmetric(vertical: 16.0, horizontal: 32.0),
                textStyle: TextStyle(fontSize: 18),
                minimumSize: Size(double.infinity,
                    50),
              ),
            ),
          ],
        ),
      ),
    );
  }
}

//book class (for api)
class Book {
  final String id;
  final String title;
  final String author;
  final String publishedDate;
  final String publisher;
  final String description;
  final double price;
  final String imageURL;
  final String previewLink;

  Book({
    required this.id,
    required this.title,
    required this.author,
    required this.publishedDate,
    required this.publisher,
    required this.description,
    required this.price,
    required this.imageURL,
    required this.previewLink,
  });
}

//book list page class
class BookListPage extends StatefulWidget {
  @override
  _BookListPageState createState() => _BookListPageState();
}

class _BookListPageState extends State<BookListPage> {
  late Future<List<Book>> futureBooks = Future.value([]);
  final CollectionReference reservedBooksCollection =
      FirebaseFirestore.instance.collection('ReservedBooks');

  Random random = Random();
  TextEditingController searchController = TextEditingController();

  //api to fetch our books
  //has error handling in ase it takes to long to fetch
  Future<List<Book>> fetchRandomBooks() async {
    final response = await http.get(
      Uri.https('www.googleapis.com', '/books/v1/volumes', {
        'q': 'subject:fiction',
        'maxResults': '20',
        'key': 'AIzaSyB_Keln8dwtYVbQ9216wJxD4aqc3sXD514',
      }),
    );

    if (response.statusCode == 200) {
      final data = jsonDecode(response.body);
      List<Book> books = [];

      for (var item in data['items']) {
        var volumeInfo = item['volumeInfo'];
        var saleInfo = item['saleInfo'];

        // Generate random price between $5 and $50
        double price = 5 + random.nextDouble() * (50 - 5);

        //adding the book
        books.add(Book(
          id: item['id'],
          title: volumeInfo['title'] ?? 'Unknown Title',
          author:
              volumeInfo['authors'] != null && volumeInfo['authors'].isNotEmpty
                  ? volumeInfo['authors'][0]
                  : 'Unknown Author',
          publishedDate: volumeInfo['publishedDate'] ?? 'Unknown Date',
          publisher: volumeInfo['publisher'] ?? 'Unknown Publisher',
          description: volumeInfo['description'] ?? 'No description available',
          price: price,
          imageURL: volumeInfo['imageLinks'] != null
              ? volumeInfo['imageLinks']['thumbnail'] ?? ''
              : '',
          previewLink: volumeInfo['previewLink'] ?? '',
        ));
      }

      return books;
    } else {
      throw Exception('Failed to fetch books');
    }
  }

  //method to reserve a book
  Future<void> reserveBook(Book book) async {
    try {
      // Check if the user has already reserved the book
      bool alreadyReserved = await checkIfBookReserved(book.id);
      if (alreadyReserved) {
        showDialog(
          context: context,
          builder: (context) => AlertDialog(
            title: Text('Error'),
            content: Text('You have already reserved this book.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: Text('OK'),
              ),
            ],
          ),
        );
        return;
      }

      // If the book is not already reserved, proceed with reservation
      await reservedBooksCollection.add({
        'userId': FirebaseAuth.instance.currentUser!.uid,
        'bookId': book.id,
        'title': book.title,
        'author': book.author,
        'publishedDate': book.publishedDate,
        'publisher': book.publisher,
        'description': book.description,
        'price': book.price,
        'imageURL': book.imageURL,
        'reservedAt': Timestamp.now(),
        'previewLink': book.previewLink,
      });

      // Show success message
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Book reserved successfully!'),
        ),
      );
    } catch (e) {
      // Show error message or handle error as needed
      print('Error reserving book: $e');
    }
  }

  //method to check if the book is reserved (uses userId and bookId)
  Future<bool> checkIfBookReserved(String bookId) async {
    try {
      // Check if the current user has already reserved the book
      var query = await reservedBooksCollection
          .where('userId', isEqualTo: FirebaseAuth.instance.currentUser!.uid)
          .where('bookId', isEqualTo: bookId)
          .get();
      return query.docs.isNotEmpty;
    } catch (e) {
      print('Error checking reservation: $e');
      return false;
    }
  }

  @override
  void initState() {
    super.initState();
    futureBooks = fetchRandomBooks();
  }

  //displaying the page display books
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Book List'),
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: TextField(
              controller: searchController,
              decoration: InputDecoration(
                hintText: 'Search by title or author',
                prefixIcon: Icon(Icons.search),
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(8.0),
                ),
              ),
              onChanged: (value) {
                setState(() {
                  // Filter books based on search query
                  futureBooks = fetchRandomBooks().then((books) => books
                      .where((book) =>
                          book.title
                              .toLowerCase()
                              .contains(value.toLowerCase()) ||
                          book.author
                              .toLowerCase()
                              .contains(value.toLowerCase()))
                      .toList());
                });
              },
            ),
          ),
          Expanded(
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: FutureBuilder<List<Book>>(
                future: futureBooks,
                builder: (context, snapshot) {
                  if (snapshot.connectionState == ConnectionState.waiting) {
                    return Center(child: CircularProgressIndicator());
                  } else if (snapshot.hasError) {
                    return Center(child: Text('Error: ${snapshot.error}'));
                  } else {
                    return ListView.builder(
                      itemCount: snapshot.data!.length,
                      itemBuilder: (context, index) {
                        Book book = snapshot.data![index];
                        return Card(
                          margin: EdgeInsets.symmetric(vertical: 8.0),
                          shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(8.0),
                          ),
                          elevation: 4.0,
                          child: ListTile(
                            leading: Image.network(
                              book.imageURL,
                              width: 50,
                              height: 50,
                              fit: BoxFit.cover,
                            ),
                            title: Text(book.title),
                            subtitle: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Text('Author: ${book.author}'),
                                SizedBox(height: 4.0),
                                Text(
                                    'Price: \$${book.price.toStringAsFixed(2)}'),
                              ],
                            ),
                            trailing: ElevatedButton(
                              onPressed: () => reserveBook(book),
                              child: Text('Reserve'),
                              style: ElevatedButton.styleFrom(
                                padding: EdgeInsets.symmetric(
                                    horizontal: 16.0, vertical: 8.0),
                                textStyle: TextStyle(fontSize: 16),
                                shape: RoundedRectangleBorder(
                                  borderRadius: BorderRadius.circular(8.0),
                                ),
                              ),
                            ),
                            onTap: () {
                              Navigator.push(
                                context,
                                MaterialPageRoute(
                                  builder: (context) =>
                                      BookDetailsPage(book: book),
                                ),
                              );
                            },
                          ),
                        );
                      },
                    );
                  }
                },
              ),
            ),
          ),
        ],
      ),
    );
  }
}

//Book details page
class BookDetailsPage extends StatelessWidget {
  final Book book;

  BookDetailsPage({required this.book});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Book Details'),
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(8.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              SizedBox(
                width: MediaQuery.of(context).size.width,
                height: 300,
                child: ClipRRect(
                  borderRadius: BorderRadius.circular(8.0),
                  child: Image.network(
                    book.imageURL,
                    fit: BoxFit.cover,
                  ),
                ),
              ),
              SizedBox(height: 16.0),
              Text(
                book.title,
                style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
              ),
              SizedBox(height: 8.0),
              Text('Author: ${book.author}'),
              Text('Published Date: ${book.publishedDate}'),
              Text('Publisher: ${book.publisher}'),
              SizedBox(height: 16.0),
              Text('Description:',
                  style: TextStyle(fontWeight: FontWeight.bold)),
              SizedBox(height: 8.0),
              Text(book.description),
              SizedBox(height: 20),
              ElevatedButton(
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => ReviewListPage(book: book),
                    ),
                  );
                },
                child: Text('View Reviews'),
                style: ElevatedButton.styleFrom(
                  padding:
                      EdgeInsets.symmetric(horizontal: 20.0, vertical: 12.0),
                  textStyle: TextStyle(fontSize: 16),
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(8.0),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}

//library page where users can see their reserved books
class LibraryPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    String? userId = FirebaseAuth.instance.currentUser?.uid;

    if (userId == null) {
      return Scaffold(
        appBar: AppBar(
          title: Text('Library'),
        ),
        body: Center(
          child: Text('Please log in to view your reserved books.'),
        ),
      );
    }

    return Scaffold(
      appBar: AppBar(
        title: Text('Library'),
      ),
      body: StreamBuilder(
        stream: FirebaseFirestore.instance
            .collection('ReservedBooks')
            .where('userId', isEqualTo: userId)
            .snapshots(),
        builder: (context, AsyncSnapshot<QuerySnapshot> snapshot) {
          if (snapshot.hasError) {
            return Center(
              child: Text('Error: ${snapshot.error}'),
            );
          }

          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(
              child: CircularProgressIndicator(),
            );
          }

          if (snapshot.data!.docs.isEmpty) {
            return Center(
              child: Text('No books reserved yet.'),
            );
          }

          //uses the api from earlier to display the contents
          return ListView.builder(
            itemCount: snapshot.data!.docs.length,
            itemBuilder: (context, index) {
              DocumentSnapshot document = snapshot.data!.docs[index];
              Map<String, dynamic> data =
              document.data() as Map<String, dynamic>;

              String id = data['id'] ?? '';
              String title = data['title'] ?? 'Unknown Title';
              String author = data['author'] ?? 'Unknown Author';
              String publishedDate = data['publishedDate'] ?? 'Unknown Date';
              String publisher = data['publisher'] ?? 'Unknown Publisher';
              String description =
                  data['description'] ?? 'No description available';
              double price = (data['price'] ?? 0.0).toDouble();
              String imageURL = data['imageURL'] ?? '';
              String previewLink = data['previewLink'] ?? '';

              Book reservedBook = Book(
                id: id,
                title: title,
                author: author,
                publishedDate: publishedDate,
                publisher: publisher,
                description: description,
                price: price,
                imageURL: imageURL,
                previewLink: previewLink,
              );

              return Card(
                margin: EdgeInsets.symmetric(vertical: 8.0),
                child: ListTile(
                  leading: Image.network(
                    reservedBook.imageURL,
                    width: 50,
                    height: 50,
                    fit: BoxFit.cover,
                  ),
                  title: Text(reservedBook.title),
                  subtitle: Text('Author: ${reservedBook.author}'),
                  trailing: Wrap(
                    children: [
                      IconButton(
                        icon: Icon(Icons.delete),
                        onPressed: () => _removeReservedBook(document.id),
                      ),
                      IconButton(
                        icon: Icon(Icons.add),
                        onPressed: () =>
                            _navigateToReviewPage(context, reservedBook),
                      ),
                      IconButton(
                        icon: Icon(Icons.book),
                        onPressed: () =>
                            _navigateToBookContentPage(context, reservedBook),
                      ),
                    ],
                  ),
                ),
              );
            },
          );
        },
      ),
    );
  }

  //method to remove the reserved books from owns library
  Future<void> _removeReservedBook(String documentId) async {
    try {
      await FirebaseFirestore.instance
          .collection('ReservedBooks')
          .doc(documentId)
          .delete();
    } catch (e) {
      print('Error removing reserved book: $e');
    }
  }

  //method to go to the review page
  void _navigateToReviewPage(BuildContext context, Book book) {
    Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => ReviewSubmissionPage(book: book)),
    );
  }

  //method to go to the book content page
  void _navigateToBookContentPage(BuildContext context, Book book) {
    Navigator.push(
      context,
      MaterialPageRoute(builder: (context) => BookContentPage(book: book)),
    );
  }
}

//class book content which lets users read the book
class BookContentPage extends StatelessWidget {
  final Book book;

  BookContentPage({required this.book});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(book.title),
      ),
      body: Center(
        child: book.previewLink.isNotEmpty
            ? ElevatedButton(
          onPressed: () async {
            String url = book.previewLink;
            try {
              await launch(url, forceSafariVC: false);
            } catch (e) {
              print('Error launching URL: $e');
              // Try launching via intent
              try {
                await launch(url, forceWebView: true);
              } catch (e) {
                print('Error launching URL via intent: $e');
                ScaffoldMessenger.of(context).showSnackBar(
                  SnackBar(
                    content: Text('Could not launch $url'),
                  ),
                );
              }
            }
          },
          child: Text('Read Book'),
        )
            : Text('No preview available for this book.'),
      ),
    );
  }
}

//review page where users can put reviews for their books
class ReviewSubmissionPage extends StatefulWidget {
  final Book book;

  ReviewSubmissionPage({required this.book});

  @override
  _ReviewSubmissionPageState createState() => _ReviewSubmissionPageState();
}

class _ReviewSubmissionPageState extends State<ReviewSubmissionPage> {
  String reviewMessage = '';
  int rating = 0;

  void _submitReview() async {
    if (reviewMessage.isNotEmpty && rating > 0) {
      try {
        await FirebaseFirestore.instance.collection('Reviews').add({
          'bookName': widget.book.title,
          'userId': FirebaseAuth.instance.currentUser?.uid,
          'reviewMessage': reviewMessage,
          'rating': rating,
          'timestamp': FieldValue.serverTimestamp(),
        });
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('Review submitted successfully')),
        );
        Navigator.pop(context); // Return to previous page after submission
      } catch (e) {
        print('Error submitting review: $e');
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('Error submitting review. Please try again.')),
        );
      }
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Please enter a review message and rating')),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Submit Review'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text('Book: ${widget.book.title}', style: TextStyle(fontSize: 18)),
            SizedBox(height: 20),
            Text('Your Review:', style: TextStyle(fontSize: 16)),
            TextField(
              decoration: InputDecoration(
                hintText: 'Write your review here',
                border: OutlineInputBorder(),
              ),
              maxLines: 5,
              onChanged: (value) {
                setState(() {
                  reviewMessage = value;
                });
              },
            ),
            SizedBox(height: 20),
            Text('Rating:', style: TextStyle(fontSize: 16)),
            Row(
              children: [
                for (int i = 1; i <= 5; i++)
                  IconButton(
                    icon: Icon(Icons.star, size: 30),
                    onPressed: () {
                      setState(() {
                        rating = i;
                      });
                    },
                    color: i <= rating ? Colors.yellow : Colors.grey,
                  ),
              ],
            ),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: _submitReview,
              child: Text('Submit Review', style: TextStyle(fontSize: 18)),
              style: ElevatedButton.styleFrom(
                padding: EdgeInsets.symmetric(vertical: 12.0),
                minimumSize: Size(double.infinity, 50),
              ),
            ),
          ],
        ),
      ),
    );
  }
}

//class to display the reviews according to the books (reviews are grouped
//by same books)
class ReviewListPage extends StatelessWidget {
  final Book book;

  ReviewListPage({required this.book});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Reviews for ${book.title}'),
      ),
      body: StreamBuilder(
        stream: FirebaseFirestore.instance
            .collection('Reviews')
            .where('bookName', isEqualTo: book.title)
            .snapshots(),
        builder: (context, AsyncSnapshot<QuerySnapshot> snapshot) {
          if (snapshot.hasError) {
            return Center(
              child: Text('Error: ${snapshot.error}'),
            );
          }

          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(
              child: CircularProgressIndicator(),
            );
          }

          // If there are no reviews for this book
          if (snapshot.data!.docs.isEmpty) {
            return Center(
              child: Text('No reviews available for this book.'),
            );
          }

          // If there are reviews, display them in a ListView
          return ListView.builder(
            itemCount: snapshot.data!.docs.length,
            itemBuilder: (context, index) {
              DocumentSnapshot document = snapshot.data!.docs[index];
              Map<String, dynamic> data =
                  document.data() as Map<String, dynamic>;

              String userId = data['userId'];
              String reviewMessage = data['reviewMessage'];
              int rating = data['rating'];

              // Fetch user details from Firestore
              return FutureBuilder<DocumentSnapshot>(
                future: FirebaseFirestore.instance
                    .collection('Users')
                    .doc(userId)
                    .get(),
                builder: (context, userSnapshot) {
                  if (userSnapshot.connectionState == ConnectionState.waiting) {
                    return ListTile(
                      title: Text(reviewMessage),
                      subtitle: Text('Rating: $rating'),
                    );
                  }

                  if (userSnapshot.hasError) {
                    return ListTile(
                      title: Text(reviewMessage),
                      subtitle: Text('Rating: $rating'),
                    );
                  }

                  if (userSnapshot.hasData && userSnapshot.data != null) {
                    var userData =
                        userSnapshot.data!.data() as Map<String, dynamic>?;
                    String userName = userData?['name'] ?? 'Unknown User';
                    String userEmail =
                        userData?['email'] ?? 'No email provided';

                    return ListTile(
                      title: Text(reviewMessage),
                      subtitle: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text('Rating: $rating'),
                          Text('By: $userName'),
                          Text('Email: $userEmail'),
                        ],
                      ),
                    );
                  } else {
                    return ListTile(
                      title: Text(reviewMessage),
                      subtitle: Text('Rating: $rating'),
                    );
                  }
                },
              );
            },
          );
        },
      ),
    );
  }
}

//community page where users can interact with each other about books
class CommunityPage extends StatefulWidget {
  @override
  _CommunityPageState createState() => _CommunityPageState();
}

//asking users for various inputs
class _CommunityPageState extends State<CommunityPage> {
  final TextEditingController _searchController = TextEditingController();
  final TextEditingController _titleController = TextEditingController();
  final TextEditingController _contentController = TextEditingController();
  String? name = "";

  void _addDiscussion() async {
    if (_titleController.text.isNotEmpty &&
        _contentController.text.isNotEmpty) {
      final userId = FirebaseAuth.instance.currentUser?.uid;
      DocumentSnapshot userSnapshot = await FirebaseFirestore.instance
          .collection('Users')
          .doc(userId)
          .get();

      if (userSnapshot.exists) {
        Map<String, dynamic>? userData =
            userSnapshot.data() as Map<String, dynamic>?;
        if (userData != null) {
          // Use name variable here
          name = userData['name'];

        } else {

        }
        await FirebaseFirestore.instance.collection('Discussions').add({
          'title': _titleController.text,
          'content': _contentController.text,
          'userId': userId,
          'name': name ?? 'Anonymous',
          'timestamp': FieldValue.serverTimestamp(),
          'likes': 0,
          'comments': 0,
        });
        _titleController.clear();
        _contentController.clear();
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('Discussion added successfully')),
        );
      } else {
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('User not found')),
        );
      }
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Please enter both title and content')),
      );
    }
  }


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Community'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          children: [
            TextField(
              controller: _searchController,
              decoration: InputDecoration(
                labelText: 'Search for books, discussions, users...',
                border: OutlineInputBorder(),
              ),
            ),
            SizedBox(height: 10),
            Row(
              children: [
                Expanded(
                  child: ElevatedButton(
                    onPressed: () {
                      showDialog(
                        context: context,
                        builder: (BuildContext context) {
                          return AlertDialog(
                            title: Text('New Discussion'),
                            content: Column(
                              mainAxisSize: MainAxisSize.min,
                              children: [
                                TextField(
                                  controller: _titleController,
                                  decoration:
                                      InputDecoration(labelText: 'Title'),
                                ),
                                TextField(
                                  controller: _contentController,
                                  decoration:
                                      InputDecoration(labelText: 'Content'),
                                  maxLines: 3,
                                ),
                              ],
                            ),
                            actions: [
                              TextButton(
                                onPressed: () {
                                  Navigator.of(context).pop();
                                },
                                child: Text('Cancel'),
                              ),
                              ElevatedButton(
                                onPressed: () {
                                  _addDiscussion();
                                  Navigator.of(context).pop();
                                },
                                child: Text('Add'),
                              ),
                            ],
                          );
                        },
                      );
                    },
                    child: Text('New Discussion'),
                  ),
                ),
                SizedBox(width: 10),
              ],
            ),
            SizedBox(height: 10),
            Expanded(
              child: StreamBuilder(
                stream: FirebaseFirestore.instance
                    .collection('Discussions')
                    .orderBy('timestamp', descending: true)
                    .snapshots(),
                builder: (context, AsyncSnapshot<QuerySnapshot> snapshot) {
                  if (snapshot.hasError) {
                    return Center(child: Text('Error: ${snapshot.error}'));
                  }

                  if (snapshot.connectionState == ConnectionState.waiting) {
                    return Center(child: CircularProgressIndicator());
                  }

                  return ListView(
                    children:
                        snapshot.data!.docs.map((DocumentSnapshot document) {
                      Map<String, dynamic> data =
                          document.data() as Map<String, dynamic>;
                      return DiscussionTile(
                        discussionId: document.id,
                        userName: data['name'] ?? 'Anonymous',
                        title: data['title'],
                        content: data['content'],
                        likes: data['likes'] ?? 0,
                        comments: data['comments'] ?? 0,
                      );
                    }).toList(),
                  );
                },
              ),
            ),
          ],
        ),
      ),
    );
  }
}

class DiscussionTile extends StatelessWidget {
  final String discussionId;
  final String userName;
  final String title;
  final String content;
  final int likes;
  final int comments;

  DiscussionTile({
    required this.discussionId,
    required this.userName,
    required this.title,
    required this.content,
    required this.likes,
    required this.comments,
  });

  void _likeDiscussion() async {
    DocumentReference discussionRef =
        FirebaseFirestore.instance.collection('Discussions').doc(discussionId);
    FirebaseFirestore.instance.runTransaction((transaction) async {
      DocumentSnapshot snapshot = await transaction.get(discussionRef);
      if (snapshot.exists) {
        int newLikes = (snapshot.data() as Map<String, dynamic>)['likes'] + 1;
        transaction.update(discussionRef, {'likes': newLikes});
      }
    });
  }

  void _addComment(BuildContext context) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        final TextEditingController _commentController =
            TextEditingController();
        return AlertDialog(
          title: Text('Add Comment'),
          content: TextField(
            controller: _commentController,
            decoration: InputDecoration(labelText: 'Comment'),
            maxLines: 3,
          ),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: Text('Cancel'),
            ),
            ElevatedButton(
              onPressed: () async {
                if (_commentController.text.isNotEmpty) {
                  final userId = FirebaseAuth.instance.currentUser?.uid;
                  DocumentSnapshot userSnapshot = await FirebaseFirestore
                      .instance
                      .collection('Users')
                      .doc(userId)
                      .get();

                  if (userSnapshot.exists) {
                    Map<String, dynamic>? userData =
                        userSnapshot.data() as Map<String, dynamic>?;
                    String? name;
                    if (userData != null) {
                      name = userData['name'];
                      // Use name variable here
                    } else {
                      // Handle the case where userData is null
                    }

                    DocumentReference discussionRef = FirebaseFirestore.instance
                        .collection('Discussions')
                        .doc(discussionId);
                    DocumentReference commentRef = await FirebaseFirestore
                        .instance
                        .collection('Discussions')
                        .doc(discussionId)
                        .collection('Comments')
                        .add({
                      'userId': FirebaseAuth.instance.currentUser?.uid,
                      'name': name ?? 'Anonymous',
                      'comment': _commentController.text,
                      'timestamp': FieldValue.serverTimestamp(),
                      'likes': 0,
                      'replies': 0,
                    });

                    FirebaseFirestore.instance
                        .runTransaction((transaction) async {
                      DocumentSnapshot snapshot =
                          await transaction.get(discussionRef);
                      if (snapshot.exists) {
                        int newComments = (snapshot.data()
                                as Map<String, dynamic>)['comments'] +
                            1;
                        transaction
                            .update(discussionRef, {'comments': newComments});
                      }
                    });
                  } else {
                    ScaffoldMessenger.of(context).showSnackBar(
                      SnackBar(content: Text('User not found')),
                    );
                  }
                  Navigator.of(context).pop();
                } else {
                  ScaffoldMessenger.of(context).showSnackBar(
                    SnackBar(content: Text('Please enter a comment')),
                  );
                }
              },
              child: Text('Add'),
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Card(
      margin: const EdgeInsets.symmetric(vertical: 8),
      child: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(title,
                style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold)),
            SizedBox(height: 8),
            Text(content),
            SizedBox(height: 8),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Row(
                  children: [
                    IconButton(
                      icon: Icon(Icons.thumb_up),
                      onPressed: _likeDiscussion,
                    ),
                    Text('$likes Likes'),
                  ],
                ),
                Row(
                  children: [
                    IconButton(
                      icon: Icon(Icons.comment),
                      onPressed: () => _addComment(context),
                    ),
                    Text('$comments Comments'),
                  ],
                ),
              ],
            ),
            CommentSection(discussionId: discussionId),
          ],
        ),
      ),
    );
  }
}

//lets user add comments to a post
class CommentSection extends StatelessWidget {
  final String discussionId;

  CommentSection({required this.discussionId});

  @override
  Widget build(BuildContext context) {
    return StreamBuilder(
      stream: FirebaseFirestore.instance
          .collection('Discussions')
          .doc(discussionId)
          .collection('Comments')
          .orderBy('timestamp', descending: true)
          .snapshots(),
      builder: (context, AsyncSnapshot<QuerySnapshot> snapshot) {
        if (snapshot.hasError) {
          return Center(child: Text('Error: ${snapshot.error}'));
        }

        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(child: CircularProgressIndicator());
        }

        return Column(
          children: snapshot.data!.docs.map((DocumentSnapshot document) {
            Map<String, dynamic> data = document.data() as Map<String, dynamic>;
            return CommentTile(
              commentId: document.id,
              discussionId: discussionId,
              userName: data['name'] ?? 'Anonymous',
              comment: data['comment'],
              likes: data['likes'] ?? 0,
              replies: data['replies'] ?? 0,
            );
          }).toList(),
        );
      },
    );
  }
}

class CommentTile extends StatelessWidget {
  final String commentId;
  final String discussionId;
  final String userName;
  final String comment;
  final int likes;
  final int replies;

  CommentTile({
    required this.commentId,
    required this.discussionId,
    required this.userName,
    required this.comment,
    required this.likes,
    required this.replies,
  });

  void _likeComment() async {
    DocumentReference commentRef = FirebaseFirestore.instance
        .collection('Discussions')
        .doc(discussionId)
        .collection('Comments')
        .doc(commentId);
    FirebaseFirestore.instance.runTransaction((transaction) async {
      DocumentSnapshot snapshot = await transaction.get(commentRef);
      if (snapshot.exists) {
        int newLikes = (snapshot.data() as Map<String, dynamic>)['likes'] + 1;
        transaction.update(commentRef, {'likes': newLikes});
      }
    });
  }

  void _replyToComment(BuildContext context) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        final TextEditingController _replyController = TextEditingController();
        return AlertDialog(
          title: Text('Reply to Comment'),
          content: TextField(
            controller: _replyController,
            decoration: InputDecoration(labelText: 'Reply'),
            maxLines: 3,
          ),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: Text('Cancel'),
            ),
            ElevatedButton(
              onPressed: () async {
                if (_replyController.text.isNotEmpty) {
                  final userId = FirebaseAuth.instance.currentUser?.uid;
                  DocumentSnapshot userSnapshot = await FirebaseFirestore
                      .instance
                      .collection('Users')
                      .doc(userId)
                      .get();

                  if (userSnapshot.exists) {
                    Map<String, dynamic>? userData =
                        userSnapshot.data() as Map<String, dynamic>?;
                    String? name;
                    if (userData != null) {
                      name = userData['name'];
                      // Use name variable here
                    } else {
                      // Handle the case where userData is null
                    }
                    DocumentReference commentRef = FirebaseFirestore.instance
                        .collection('Discussions')
                        .doc(discussionId)
                        .collection('Comments')
                        .doc(commentId);
                    await FirebaseFirestore.instance
                        .collection('Discussions')
                        .doc(discussionId)
                        .collection('Comments')
                        .doc(commentId)
                        .collection('Replies')
                        .add({
                      'userId': FirebaseAuth.instance.currentUser?.uid,
                      'name': name ?? 'Anonymous',
                      'reply': _replyController.text,
                      'timestamp': FieldValue.serverTimestamp(),
                      'likes': 0,
                    });
                    FirebaseFirestore.instance
                        .runTransaction((transaction) async {
                      DocumentSnapshot snapshot =
                          await transaction.get(commentRef);
                      if (snapshot.exists) {
                        int newReplies = (snapshot.data()
                                as Map<String, dynamic>)['replies'] +
                            1;
                        transaction.update(commentRef, {'replies': newReplies});
                      }
                    });
                  } else {
                    ScaffoldMessenger.of(context).showSnackBar(
                      SnackBar(content: Text('User not found')),
                    );
                  }
                  Navigator.of(context).pop();
                } else {
                  ScaffoldMessenger.of(context).showSnackBar(
                    SnackBar(content: Text('Please enter a reply')),
                  );
                }
              },
              child: Text('Reply'),
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Card(
      margin: const EdgeInsets.symmetric(vertical: 4),
      child: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(userName, style: TextStyle(fontWeight: FontWeight.bold)),
            SizedBox(height: 4),
            Text(comment),
            SizedBox(height: 8),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Row(
                  children: [
                    IconButton(
                      icon: Icon(Icons.thumb_up),
                      onPressed: _likeComment,
                    ),
                    Text('$likes Likes'),
                  ],
                ),
                Row(
                  children: [
                    IconButton(
                      icon: Icon(Icons.reply),
                      onPressed: () => _replyToComment(context),
                    ),
                    Text('$replies Replies'),
                  ],
                ),
              ],
            ),
            ReplySection(discussionId: discussionId, commentId: commentId),
          ],
        ),
      ),
    );
  }
}

//lets users reply to the comments on the post
class ReplySection extends StatelessWidget {
  final String discussionId;
  final String commentId;

  ReplySection({required this.discussionId, required this.commentId});

  @override
  Widget build(BuildContext context) {
    return StreamBuilder(
      stream: FirebaseFirestore.instance
          .collection('Discussions')
          .doc(discussionId)
          .collection('Comments')
          .doc(commentId)
          .collection('Replies')
          .orderBy('timestamp', descending: true)
          .snapshots(),
      builder: (context, AsyncSnapshot<QuerySnapshot> snapshot) {
        if (snapshot.hasError) {
          return Center(child: Text('Error: ${snapshot.error}'));
        }

        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(child: CircularProgressIndicator());
        }

        return Column(
          children: snapshot.data!.docs.map((DocumentSnapshot document) {
            Map<String, dynamic> data = document.data() as Map<String, dynamic>;
            return ListTile(
              title: Text(data['name'] ?? 'Anonymous'),
              subtitle: Text(data['reply']),
              trailing: Row(
                mainAxisSize: MainAxisSize.min,
                children: [
                  IconButton(
                    icon: Icon(Icons.thumb_up),
                    onPressed: () {
                      DocumentReference replyRef = FirebaseFirestore.instance
                          .collection('Discussions')
                          .doc(discussionId)
                          .collection('Comments')
                          .doc(commentId)
                          .collection('Replies')
                          .doc(document.id);
                      FirebaseFirestore.instance
                          .runTransaction((transaction) async {
                        DocumentSnapshot snapshot =
                            await transaction.get(replyRef);
                        if (snapshot.exists) {
                          int newLikes = (snapshot.data()
                                  as Map<String, dynamic>)['likes'] +
                              1;
                          transaction.update(replyRef, {'likes': newLikes});
                        }
                      });
                    },
                  ),
                  Text('${data['likes'] ?? 0}'),
                ],
              ),
            );
          }).toList(),
        );
      },
    );
  }
}

//login page where user enteres usernname and password
class LoginPage extends StatelessWidget {
  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();

  LoginPage() {
    _emailController.text = '';
    _passwordController.text = '';
  }

  //validates if they are in the same group
  Future<void> _loginWithEmailAndPassword(BuildContext context) async {
    try {
      UserCredential userCredential =
          await FirebaseAuth.instance.signInWithEmailAndPassword(
        email: _emailController.text,
        password: _passwordController.text,
      );

      // Navigate to home screen after successful login
      Navigator.pushReplacement(
        context,
        MaterialPageRoute(builder: (context) => MyHomePage()),
      );
    } catch (e) {
      // Handle errors
      print('Failed to login: $e');
      // Show error message to the user
      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          title: Text('Error'),
          content: Text(
              'Failed to login. Please check your credentials and try again.'),
          actions: [
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: Text('OK'),
            ),
          ],
        ),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text(
              'Bibliotech',
              style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 16.0),
            TextFormField(
              controller: _emailController,
              decoration: InputDecoration(labelText: 'Email'),
            ),
            SizedBox(height: 16.0),
            TextFormField(
              controller: _passwordController,
              decoration: InputDecoration(labelText: 'Password'),
              obscureText: true,
            ),
            SizedBox(height: 16.0),
            ElevatedButton(
              onPressed: () => _loginWithEmailAndPassword(context),
              child: Text('Login'),
            ),
            SizedBox(height: 16.0),
            RichText(
              text: TextSpan(
                text: 'Don\'t have an account? ',
                style: TextStyle(color: Colors.black),
                children: [
                  TextSpan(
                    text: 'Sign up here',
                    style: TextStyle(
                      color: Colors.blue,
                      decoration: TextDecoration.underline,
                    ),
                    // Add onPressed callback for navigation
                    recognizer: TapGestureRecognizer()
                      ..onTap = () {
                        Navigator.push(
                          context,
                          MaterialPageRoute(
                              builder: (context) => RegisterPage()),
                        );
                      },
                  ),
                ],
              ),
            ),
            SizedBox(height: 16.0),
            RichText(
              text: TextSpan(
                text: 'Forgot your password? ',
                style: TextStyle(color: Colors.black),
                children: [
                  TextSpan(
                    text: 'Reset it here',
                    style: TextStyle(
                      color: Colors.blue,
                      decoration: TextDecoration.underline,
                    ),
                    // Add onPressed callback for navigation
                    recognizer: TapGestureRecognizer()
                      ..onTap = () {
                        // Navigate to forgot password page
                        Navigator.push(
                          context,
                          MaterialPageRoute(
                              builder: (context) => ForgotPasswordPage()),
                        );
                      },
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}

//forgot password page
//send an email with a link to reset the password
class ForgotPasswordPage extends StatelessWidget {
  final TextEditingController _emailController = TextEditingController();

  Future<void> _resetPassword(BuildContext context) async {
    try {
      await FirebaseAuth.instance.sendPasswordResetEmail(
        email: _emailController.text,
      );

      // Show success message to the user
      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          title: Text('Success'),
          content: Text('Password reset email sent. Please check your email.'),
          actions: [
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: Text('OK'),
            ),
          ],
        ),
      );
    } catch (e) {
      //  error handling
      print('Failed to send password reset email: $e');
      // Show error message to the user
      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          title: Text('Error'),
          content:
              Text('Failed to send password reset email. Please try again.'),
          actions: [
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: Text('OK'),
            ),
          ],
        ),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Forgot Password'),
        centerTitle: true,
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text(
              'Forgot Your Password?',
              style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 16.0),
            Text(
              'Enter your email address below to receive a password reset link.',
              textAlign: TextAlign.center,
            ),
            SizedBox(height: 16.0),
            TextFormField(
              controller: _emailController,
              decoration: InputDecoration(labelText: 'Email'),
            ),
            SizedBox(height: 16.0),
            ElevatedButton(
              onPressed: () => _resetPassword(context),
              child: Text('Reset Password'),
            ),
          ],
        ),
      ),
    );
  }
}

//profile page where users can change their profile picture
//change their password and account info
class ProfilePage extends StatefulWidget {
  @override
  _ProfilePageState createState() => _ProfilePageState();
}

class _ProfilePageState extends State<ProfilePage> {
  File? _image;

  //allowing the user to pick and image
  Future<void> _pickImage() async {
    final picker = ImagePicker();
    final pickedFile = await picker.pickImage(source: ImageSource.gallery);
    if (pickedFile != null) {
      setState(() {
        _image = File(pickedFile.path);
      });
    }
  }

  //uploading the image to the firebase storage
  Future<String?> _uploadImage() async {
    try {
      if (_image != null) {
        // Upload image to Firebase Storage
        final fileName = DateTime.now().millisecondsSinceEpoch.toString();
        final destination = 'user_profile_images/$fileName';
        final ref = FirebaseStorage.instance.ref().child(destination);
        await ref.putFile(_image!);

        // Get download URL
        final url = await ref.getDownloadURL();
        return url;
      }
    } catch (e) {
      print('Error uploading image: $e');
    }
    return null;
  }

  //saving the profile picture to the database
  Future<void> _saveProfile() async {
    try {
      final imageUrl = await _uploadImage();
      if (imageUrl != null) {
        // Update user profile in Firestore
        final uid = FirebaseAuth.instance.currentUser!.uid;
        final userRef = FirebaseFirestore.instance.collection('Users').doc(uid);
        await userRef.update({'profileImage': imageUrl});
        print('Profile updated with image URL');
      } else {
        print('No image URL to save.');
      }
    } catch (e) {
      print('Error saving profile: $e');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          'Profile',
          style: TextStyle(fontSize: 32, fontWeight: FontWeight.bold),
        ),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: StreamBuilder<DocumentSnapshot>(
          stream: FirebaseFirestore.instance
              .collection('Users')
              .doc(FirebaseAuth.instance.currentUser!.uid)
              .snapshots(),
          builder: (context, snapshot) {
            if (snapshot.connectionState == ConnectionState.waiting) {
              return CircularProgressIndicator();
            } else if (snapshot.hasError) {
              return Text('Error: ${snapshot.error}');
            } else {
              var userData = snapshot.data!.data() as Map<String, dynamic>;
              var userEmail = userData['email'] ?? 'No email found';
              var userName = userData['name'] ?? 'No name found';
              var profileImageUrl = userData['profileImage'] ?? null;
              return Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  SizedBox(height: 0.0),
                  CircleAvatar(
                    radius: 50,
                    backgroundImage: _image != null
                        ? FileImage(_image!)
                        : profileImageUrl != null
                            ? NetworkImage(profileImageUrl)
                            : AssetImage('assets/default_profile_image.png')
                                as ImageProvider<Object>,
                  ),
                  SizedBox(height: 16.0),
                  ElevatedButton(
                    onPressed: () async {
                      await _pickImage();
                      await _saveProfile();
                    },
                    child: Text('Change Image'),
                  ),
                  SizedBox(height: 16.0),
                  Text(
                    'Name: $userName',
                    style: TextStyle(fontSize: 18),
                  ),
                  SizedBox(height: 8.0),
                  Text(
                    'Email: $userEmail',
                    style: TextStyle(fontSize: 18),
                  ),
                  SizedBox(height: 16.0),
                  Text(
                    'Account Settings',
                    style: TextStyle(fontSize: 18, color: Colors.grey),
                  ),
                  SizedBox(height: 16.0),
                  Row(
                    children: [
                      Expanded(
                        child: ElevatedButton(
                          onPressed: () {
                            // Navigate to the ForgotPasswordPage
                            Navigator.push(
                              context,
                              MaterialPageRoute(
                                  builder: (context) => ForgotPasswordPage()),
                            );
                          },
                          child: Text('Change Password'),
                        ),
                      ),
                      SizedBox(width: 8.0),
                      Expanded(
                        child: ElevatedButton(
                          onPressed: () {
                            Navigator.push(
                              context,
                              MaterialPageRoute(
                                  builder: (context) => EditProfilePage()),
                            );
                          },
                          child: Text('Edit Profile'),
                        ),
                      ),
                    ],
                  ),
                ],
              );
            }
          },
        ),
      ),
    );
  }
}

//edit profile class where users can edit their name and email
class EditProfilePage extends StatefulWidget {
  @override
  _EditProfilePageState createState() => _EditProfilePageState();
}

//asking the user for their input
class _EditProfilePageState extends State<EditProfilePage> {
  late TextEditingController _nameController;
  late TextEditingController _emailController;
  String? previousEmail;

  @override
  void initState() {
    super.initState();
    // Initialize text controllers with current user information
    _nameController = TextEditingController();
    _emailController = TextEditingController();
    _loadUserProfile();
  }

  @override
  void dispose() {
    // Dispose text controllers
    _nameController.dispose();
    _emailController.dispose();
    super.dispose();
  }

  void _loadUserProfile() async {
    // Load user profile data from Firestore and set the text controllers
    try {
      DocumentSnapshot userSnapshot = await FirebaseFirestore.instance
          .collection('Users')
          .doc(FirebaseAuth.instance.currentUser!.uid)
          .get();
      if (userSnapshot.exists) {
        setState(() {
          _nameController.text = userSnapshot['name'] ?? '';
          previousEmail = userSnapshot['email'];
          _emailController.text = previousEmail ?? '';
        });
      }
    } catch (e) {
      print('Error loading user profile: $e');
    }
  }

  void _saveProfileChanges() async {
    // Save the updated profile information to Firestore
    try {
      await FirebaseFirestore.instance
          .collection('Users')
          .doc(FirebaseAuth.instance.currentUser!.uid)
          .update({
        'name': _nameController.text,
        'email': _emailController.text.isEmpty
            ? previousEmail
            : _emailController.text,
      });
      // Navigate back to the ProfilePage after saving changes
      Navigator.pop(context); // Close the EditProfilePage
    } catch (e) {
      print('Error saving profile changes: $e');
      // Show error message to the user if saving fails
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Failed to save profile changes. Please try again.'),
        ),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Edit Profile'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            TextField(
              controller: _nameController,
              decoration: InputDecoration(labelText: 'Name'),
            ),
            SizedBox(height: 16.0),
            TextField(
              controller: _emailController,
              decoration: InputDecoration(labelText: 'Email'),
            ),
            SizedBox(height: 16.0),
            ElevatedButton(
              onPressed: _saveProfileChanges,
              child: Text('Save Changes'),
            ),
          ],
        ),
      ),
    );
  }
}
//settings page where users can set dark mode, contact customer support
//and basic FAQ
class SettingsPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    var themeProvider = Provider.of<ThemeProvider>(context);

    return Scaffold(
      appBar: AppBar(
        title: Text(
          'Settings',
          style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
        ),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            SizedBox(height: 1.0),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(
                  'Dark Mode',
                  style: TextStyle(fontSize: 18),
                ),
                Switch(
                  value: themeProvider.isDarkMode,
                  onChanged: (value) {
                    themeProvider.toggleTheme();
                  },
                ),
              ],
            ),
            SizedBox(height: 16.0),
            GestureDetector(
              onTap: () {
                _showFAQ(context);
              },
              child: Container(
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10.0),
                  color: themeProvider.isDarkMode
                      ? Colors.grey[800]
                      : Colors.grey[200],
                ),
                width: double.infinity,
                padding: EdgeInsets.all(16.0),
                child: Text(
                  'Help and Support',
                  style: TextStyle(
                    fontSize: 18,
                    color:
                        themeProvider.isDarkMode ? Colors.white : Colors.black,
                  ),
                ),
              ),
            ),
            SizedBox(height: 16.0),
            GestureDetector(
              onTap: () {
                // Logout functionality
                FirebaseAuth.instance.signOut();
                Navigator.pushReplacement(
                  context,
                  MaterialPageRoute(builder: (context) => LoginPage()),
                );
              },
              child: Container(
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10.0),
                  color: themeProvider.isDarkMode
                      ? Colors.grey[800]
                      : Colors.grey[200],
                ),
                width: double.infinity,
                padding: EdgeInsets.all(16.0),
                child: Text(
                  'Logout',
                  style: TextStyle(
                    fontSize: 18,
                    color:
                        themeProvider.isDarkMode ? Colors.white : Colors.black,
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }

  //method to display the FAQ
  void _showFAQ(BuildContext context) {
    // Show a dialog with FAQ or navigate to a FAQ page
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text("FAQ"),
          content: SingleChildScrollView(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text("Q: How do I reset my password?"),
                SizedBox(height: 8),
                Text("A: You can reset your password by going in your profile and clicking change password button"),
                SizedBox(height: 16),
                Text("Q: Can I change my username?"),
                SizedBox(height: 8),
                Text("A: Yes, head over to your profile where you can edit your profile details."),
              ],
            ),
          ),
          actions: <Widget>[
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: Text('Close'),
            ),
            TextButton(
              onPressed: () {
                // Navigate to feedback form page
                Navigator.of(context).pop();
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => FeedbackFormPage()),
                );
              },
              child: Text('Submit Feedback'),
            ),
          ],
        );
      },
    );
  }
}

//feedback class that allows the user to send a ticket
class FeedbackFormPage extends StatelessWidget {
  final TextEditingController subjectController = TextEditingController();
  final TextEditingController messageController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Feedback'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              'Submit Feedback',
              style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 16.0),
            TextFormField(
              controller: subjectController,
              decoration: InputDecoration(
                labelText: 'Subject',
                border: OutlineInputBorder(),
              ),
            ),
            SizedBox(height: 16.0),
            TextFormField(
              controller: messageController,
              maxLines: 5,
              decoration: InputDecoration(
                labelText: 'Message',
                border: OutlineInputBorder(),
              ),
            ),
            SizedBox(height: 16.0),
            OutlinedButton(
              onPressed: () {
                _submitFeedback(context);
              },
              child: Text('Submit'),
            ),
          ],
        ),
      ),
    );
  }

  //method that ask user their input
  //and once the user clicks send it records
  //thier message to the database
  void _submitFeedback(BuildContext context) async {
    String subject = subjectController.text.trim();
    String message = messageController.text.trim();

    if (subject.isNotEmpty && message.isNotEmpty) {
      // Save feedback to Firestore
      await FirebaseFirestore.instance.collection('feedback').add({
        'subject': subject,
        'message': message,
        'timestamp': DateTime.now(),
      });

      // Clear text fields
      subjectController.clear();
      messageController.clear();

      // Navigate back to Help and Support page
      Navigator.pop(context);
    } else {
      // Show error message if subject or message is empty
      ScaffoldMessenger.of(context).showSnackBar(SnackBar(
        content: Text('Please enter both subject and message.'),
      ));
    }
  }
}

//event page where users can reserve to attend to these events
class EventPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Events'),
      ),
      body: ListView(
        children: [
          EventWidget(
            event: Event(
              name: 'Book Signing Event',
              imageUrl:
                  'https://static.wikia.nocookie.net/lotr/images/8/87/Ringstrilogyposter.jpg/revision/latest/scale-to-width-down/1000?cb=20210720095933',
              dateTime: DateTime(2024, 4, 18, 12, 30),
              // Friday, April 18th, 12:30 PM
              description:
                  'During the event, attendees would have the opportunity to meet Tolkien, briefly converse with him, and have their books signed. It\'s a special occasion for fans to connect with the author, express their admiration for his work, and obtain a personalized memento in the form of a signed book.',
              location: '4545 Pierre-de Coubertin Ave\nMontreal, QC. H1V 3N7',
              spotsRemaining: 250,
            ),
          ),

          EventWidget(
            event: Event(
              name: 'Book Signing Event',
              imageUrl:
                  'https://cdn.mos.cms.futurecdn.net/d4RuRPLJHfAyUJiusHpZem-650-80.jpg.webp',
              dateTime: DateTime(2024, 4, 20, 10, 30),
              // Friday, April 18th, 12:30 PM
              description:
                  'During the event, fans will have the chance to meet Rob MacGregor, the acclaimed author of numerous Indiana Jones novels. They can enjoy a brief conversation with him and get their books signed. This is a unique opportunity to connect with the author, share their appreciation for his work, and leave with a special signed memento',
              location: '4545 Pierre-de Coubertin Ave\nMontreal, QC. H1V 3N7',
              spotsRemaining: 50,
            ),
          ),

          EventWidget(
            event: Event(
              name: 'Book Signing Event',
              imageUrl:
              'https://static0.gamerantimages.com/wordpress/wp-content/uploads/2021/12/avp-2010.jpg?q=50&fit=contain&w=1140&h=&dpr=1.5',
              dateTime: DateTime(2024, 12, 4, 10, 30),
              // Friday, April 18th, 12:30 PM
              description:
              'At the event, attendees would have the chance to meet Steve Perry, engage in brief conversations with him, and have their books signed. Its a special occasion for fans to connect directly with the author, express their admiration for his work, and obtain a personalized memento in the form of a signed book',
              location: '4545 Pierre-de Coubertin Ave\nMontreal, QC. H1V 3N7',
              spotsRemaining: 20,
            ),
          ),
        ],
      ),
    );
  }
}

//event class
class Event {
  final String name;
  final String imageUrl;
  final DateTime dateTime;
  final String description;
  final String location;
  final int spotsRemaining;

  Event({
    required this.name,
    required this.imageUrl,
    required this.dateTime,
    required this.description,
    required this.location,
    required this.spotsRemaining,
  });
}
//event widget class for general info
class EventWidget extends StatelessWidget {
  final Event event;

  EventWidget({required this.event});

  @override
  Widget build(BuildContext context) {
    var themeProvider = Provider.of<ThemeProvider>(context);
    Color backgroundColor = themeProvider.isDarkMode
        ? Colors.grey[800] ?? Colors.black
        : Colors.grey[200] ?? Colors.white;
    Color textColor = themeProvider.isDarkMode ? Colors.white : Colors.black;

    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            event.name,
            style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
          ),
          SizedBox(height: 8),
          Image.network(
            event.imageUrl,
            height: 200,
            width: double.infinity,
            fit: BoxFit.cover,
          ),
          SizedBox(height: 8),
          Text(
            '${DateFormat('EEEE, MMMM d || hh:mm a').format(event.dateTime)}',
          ),
          SizedBox(height: 8),
          Text(
            event.description, // Use event.description here
            style: TextStyle(color: textColor),
          ),
          SizedBox(height: 8),
          Container(
            padding: EdgeInsets.all(8),
            decoration: BoxDecoration(
              color: backgroundColor,
              borderRadius: BorderRadius.circular(8),
            ),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  'Event Location:',
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                    color: textColor,
                  ),
                ),
                SizedBox(height: 4),
                Text(
                  event.location ?? '',
                  style: TextStyle(color: textColor),
                ),
                SizedBox(height: 8),
                Text(
                  'Spots Remaining: ${event.spotsRemaining}',
                  style: TextStyle(color: textColor),
                ),
              ],
            ),
          ),
          SizedBox(height: 8),
          ElevatedButton(
            onPressed: () {
              if (event.spotsRemaining > 0) {
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => ReservationConfirmationPage(
                      name: '',
                      email: '',
                      event: event,
                    ),
                  ),
                );
              }
            },
            child: Text('Reserve Now'),
          ),
        ],
      ),
    );
  }
}

//once you reserve confirmation page will display
class ReservationConfirmationPage extends StatelessWidget {
  final String name;
  final String email;
  final Event event;

  ReservationConfirmationPage(
      {required this.name, required this.email, required this.event});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Reservation Confirmation'),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Icon(
              Icons.check_circle,
              color: Colors.green,
              size: 100,
            ),
            SizedBox(height: 20),
            Text(
              'Congratulations!',
              style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 10),
            Text('Your event ticket has been successfully reserved.'),
            SizedBox(height: 20),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: () {
                Navigator.pop(context);
              },
              child: Text('Go Back'),
            ),
          ],
        ),
      ),
    );
  }
}
