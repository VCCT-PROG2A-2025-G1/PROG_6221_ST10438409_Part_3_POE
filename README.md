# Cybersecurity Chatbot

This is a simple console-based chatbot designed to educate users about cybersecurity topics such as password security, phishing scams, safe browsing, and more. The chatbot also includes fun interactions and personalized responses using the user's name.

Youtube Video 
Demo: [Cybersecurity Chatbot Demo](https://youtu.be/RThOkKN5AXs)


---

## Features
- **Personalized Responses**: The chatbot addresses the user by their name for a more engaging experience.
- **Cybersecurity Education**: Learn about password security, phishing scams, safe browsing, and other cybersecurity topics.
- **Interactive Q&A**: Ask the chatbot questions and receive helpful answers.
- **Fun Interactions**: Includes jokes and lighthearted responses to keep the conversation enjoyable.

---

## Prerequisites
- **.NET Framework 4.8**: Ensure you have the .NET Framework 4.8 installed on your system.
- **Visual Studio 2022**: Open the project in Visual Studio for development and debugging.

---

## Installation
1. Clone the repository:
2. Open the solution file (`.sln`) in Visual Studio 2022.
3. Build the project to restore dependencies and compile the code.

---

## Usage
1. Run the program in Visual Studio or from the command line.
2. The chatbot will greet you and ask for your name.
3. Type your name to start the conversation.
4. Ask the chatbot questions about cybersecurity or type `help` to see a list of possible questions.
5. To exit the program, type `exit`.

---

## Example Interaction
Chatbot: Hello! Welcome to the Cybersecurity Chatbot. 
What's your name? 
You: Dylan 

Chatbot: Nice to meet you, Dylan! How can I help you today? 
You: How do I create a strong password? 

Chatbot: Make sure to use a mix of uppercase and lowercase letters, numbers, and special characters, Dylan. Avoid anything easy to guess like your name or birthday. 

You: exit 
Chatbot: Goodbye Dylan, have a great day!

---

## File Structure
- **Program.cs**: Entry point of the application. Handles user input and chatbot responses.
- **ChatbotLogic.cs**: Contains the logic for loading responses and generating answers.
- **Resources/Response.json**: Stores predefined chatbot responses categorized by topics.
- **Communication.cs**: Handles text-to-speech and user interaction methods.
- **ConsoleFormat.cs**: Manages console formatting, such as text color and borders.

---

## Customization
- **Personalized Responses**: Update the `Response.json` file to include `{UserName}` placeholders for dynamic responses.
- **Add New Topics**: Extend the `Response.json` file with new categories and questions.
- **Modify Appearance**: Customize the console formatting in `ConsoleFormat.cs`.

---

## Contributing
Contributions are welcome! Feel free to submit a pull request or open an issue for suggestions and improvements.
