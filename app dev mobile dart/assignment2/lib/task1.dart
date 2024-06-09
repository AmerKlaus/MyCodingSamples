import 'package:flutter/material.dart';
import 'package:sqflite/sqflite.dart';
import 'package:path/path.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'CRUD with SQLite',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: HomePage(),
    );
  }
}

class HomePage extends StatefulWidget {
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  late Database _database;
  List<Map<String, dynamic>> _users = [];

  final TextEditingController _firstNameController = TextEditingController();
  final TextEditingController _lastNameController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _initializeDatabase();
  }

  Future<void> _initializeDatabase() async {
    _database = await openDatabase(
      join(await getDatabasesPath(), 'user_database.db'),
      onCreate: (db, version) {
        return db.execute(
          'CREATE TABLE users(id INTEGER PRIMARY KEY, firstName TEXT, lastName TEXT)',
        );
      },
      version: 1,
    );
    _refreshUserList();
  }

  Future<void> _refreshUserList() async {
    final List<Map<String, dynamic>> users = await _database.query('users');
    setState(() {
      _users = users;
    });
  }

  Future<void> _addUser() async {
    await _database.insert(
      'users',
      {
        'firstName': _firstNameController.text,
        'lastName': _lastNameController.text,
      },
      conflictAlgorithm: ConflictAlgorithm.replace,
    );
    _firstNameController.clear();
    _lastNameController.clear();
    _refreshUserList();
  }

  Future<void> _updateUser(int id, String newFirstName, String newLastName) async {
    await _database.update(
      'users',
      {
        'firstName': newFirstName,
        'lastName': newLastName,
      },
      where: 'id = ?',
      whereArgs: [id],
    );
    _refreshUserList();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('CRUD with SQLite'),
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              children: [
                Expanded(
                  child: TextField(
                    controller: _firstNameController,
                    decoration: InputDecoration(labelText: 'First Name'),
                  ),
                ),
                SizedBox(width: 8.0),
                Expanded(
                  child: TextField(
                    controller: _lastNameController,
                    decoration: InputDecoration(labelText: 'Last Name'),
                  ),
                ),
                SizedBox(width: 8.0),
                ElevatedButton(
                  onPressed: _addUser,
                  child: Text('Add'),
                ),
              ],
            ),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: _users.length,
              itemBuilder: (context, index) {
                final user = _users[index];
                return ListTile(
                  title: Text('${user['firstName']} ${user['lastName']}'),
                  trailing: Row(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      IconButton(
                        icon: Icon(Icons.edit),
                        onPressed: () {
                          TextEditingController firstNameController = TextEditingController(text: user['firstName']);
                          TextEditingController lastNameController = TextEditingController(text: user['lastName']);

                          showDialog(
                            context: context,
                            builder: (context) => AlertDialog(
                              title: Text('Edit User'),
                              content: Column(
                                mainAxisSize: MainAxisSize.min,
                                children: [
                                  TextField(
                                    controller: firstNameController,
                                    onChanged: (value) {
                                      // No need to update user['firstName'] here
                                    },
                                    decoration: InputDecoration(labelText: 'First Name'),
                                  ),
                                  TextField(
                                    controller: lastNameController,
                                    onChanged: (value) {
                                      // No need to update user['lastName'] here
                                    },
                                    decoration: InputDecoration(labelText: 'Last Name'),
                                  ),
                                ],
                              ),
                              actions: [
                                ElevatedButton(
                                  onPressed: () {
                                    _updateUser(user['id'], firstNameController.text, lastNameController.text);
                                    Navigator.of(context).pop();
                                  },
                                  child: Text('Save'),
                                ),
                              ],
                            ),
                          );
                        },
                      ),
                      IconButton(
                        icon: Icon(Icons.delete),
                        onPressed: () {
                          _deleteUser(user['id']);
                        },
                      ),
                    ],
                  ),
                );
              },
            ),
          ),
        ],
      ),
    );
  }

  Future<void> _deleteUser(int id) async {
    await _database.delete(
      'users',
      where: 'id = ?',
      whereArgs: [id],
    );
    _refreshUserList();
  }

  @override
  void dispose() {
    _database.close();
    super.dispose();
  }
}