# Cybersecurity Chatbot

This is a console-based chatbot designed to educate users about cybersecurity topics such as password security, phishing scams, safe browsing, and more. The chatbot features fun interactions, personalized responses using the user's name, and improved usability based on recent updates.

---

## Demo Videos

- **YouTube Video Part 1:** [Cybersecurity Chatbot Demo (Part 1)](https://youtu.be/RThOkKN5AXs)
- **YouTube Video Part 2:** [Cybersecurity Chatbot Demo (Part 2)](https://youtu.be/Uc0FjkQAyYA)

---

## Features

- **Personalized Responses:** The chatbot addresses the user by their name for a more engaging experience.
- **Cybersecurity Education:** Learn about password security, phishing scams, safe browsing, and other cybersecurity topics.
- **Interactive Q&A:** Ask the chatbot questions and receive helpful, context-aware answers.
- **Fun Interactions:** Includes jokes and lighthearted responses to keep the conversation enjoyable.
- **Text-to-Speech Support:** The chatbot can read responses aloud for accessibility (requires enabled audio).
- **Enhanced Help System:** Type `help` at any time to see a list of supported questions and topics.
- **Improved Error Handling:** The chatbot now provides clearer feedback for unrecognized questions or commands.

---

## Prerequisites

- **.NET Framework 4.8:** Ensure you have the .NET Framework 4.8 installed on your system.
- **Visual Studio 2022:** Open the project in Visual Studio for development and debugging.

---

## Installation

1. **Clone the repository:**
   - git clone https://github.com/VCCT-PROG2A-2025-G1/PROG_6221_ST10438409_Part_2
2. **Open the solution:**
   - Launch Visual Studio 2022.
   - Open the `.sln` file from the cloned repository.
3. **Build the project:**
   - Restore dependencies and compile the code using the Build menu or by pressing `Ctrl+Shift+B`.

---

## Usage

1. **Run the program:**
   - Press `F5` in Visual Studio or run the compiled executable from the command line.
2. **Start the conversation:**
   - The chatbot will greet you and ask for your name.
   - Enter your name to begin.
3. **Ask questions:**
   - Type questions about cybersecurity (e.g., "How do I create a strong password?").
   - Type `help` to see a list of supported questions and topics.
   - Type `joke` for a fun interaction.
   - Type `exit` to end the session.
4. **Text-to-Speech:**
   - If your system supports it, responses will be read aloud for accessibility.

---

## Example Interaction

Chatbot: Hello! Welcome to the Cybersecurity Chatbot. What's your name? 
You: Dylan

Chatbot: Nice to meet you, Dylan! How can I help you today? 
You: How do I create a strong password?

Chatbot: Make sure to use a mix of uppercase and lowercase letters, numbers, and special characters, Dylan. Avoid anything easy to guess like your name or birthday.
You: help

Chatbot: You can ask about:
•	Password security
•	Phishing scams
•	Safe browsing
•	Social engineering
•	And more!
You: joke

Chatbot: Why did the computer go to therapy? It had too many bytes of emotional baggage!
You: exit

Chatbot: Goodbye Dylan, have a great day!

---

## File Structure

- **Program.cs:** Entry point of the application. Handles user input and chatbot responses.
- **ChatbotLogic.cs:** Contains the logic for loading responses and generating answers.
- **Resources/Response.json:** Stores predefined chatbot responses categorized by topics.
- **Communication.cs:** Handles text-to-speech and user interaction methods.
- **ConsoleFormat.cs:** Manages console formatting, such as text color and borders.

---

## Customization

- **Personalized Responses:** Update the `Response.json` file to include `{UserName}` placeholders for dynamic responses.
- **Add New Topics:** Extend the `Response.json` file with new categories and questions.
- **Modify Appearance:** Customize the console formatting in `ConsoleFormat.cs`.
- **Enable/Disable Text-to-Speech:** Adjust settings in `Communication.cs` to control audio output.

---