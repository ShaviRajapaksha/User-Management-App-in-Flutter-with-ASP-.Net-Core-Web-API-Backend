import 'package:flutter/material.dart';
import '../utils/auth_storage.dart';
import 'login_screen.dart';

class UserHome extends StatelessWidget {
  const UserHome({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("User Home"),
        actions: [
          IconButton(
            icon: const Icon(Icons.logout),
            onPressed: () async {
              await AuthStorage.logout();
              Navigator.pushReplacement(
                context,
                MaterialPageRoute(builder: (_) => const LoginScreen()),
              );
            },
          ),
        ],
      ),
      body: const Center(
        child: Text("Welcome User 🙋", style: TextStyle(fontSize: 22)),
      ),
    );
  }
}
