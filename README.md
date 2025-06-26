#\PROG_6221_ST10438409_Part_3_POE\README.md
# Cybersecurity Chatbot

This project is a comprehensive, console and GUI-based chatbot application designed to educate users on a wide range of cybersecurity topics. The chatbot provides interactive, personalized conversations to help users understand best practices in areas such as password security, phishing scams, safe browsing, social engineering, and more. The latest version (Part 3) introduces a modernized user experience with Windows Forms, advanced task and reminder management, activity logging, and a mini-quiz feature.

---

## Demo Videos

- **YouTube Video Part 1:** [Cybersecurity Chatbot Demo (Part 1)](https://youtu.be/RThOkKN5AXs)
- **YouTube Video Part 2:** [Cybersecurity Chatbot Demo (Part 2)](https://youtu.be/Uc0FjkQAyYA)
- **YouTube Video Part 3:** [Cybersecurity Chatbot Demo (Part 3)](https://youtu.be/b6MAXRMcszE)

---

## What's New in Part 3

### New Classes and Forms

- **TaskAssistant_GUI:**  
  A Windows Form for creating and managing tasks and reminders. Users can specify custom timeframes, set reminder dates, and interact with a modern, styled interface.

- **DisplayAllTasks:**  
  A dedicated form to display all saved tasks in a user-friendly, read-only format. Tasks are loaded from a persistent file and presented with professional styling.

- **Mini_Quiz_GUI:**  
  An interactive quiz form that tests users' cybersecurity knowledge. The quiz tracks progress, provides immediate feedback, and is fully integrated with the chatbot's activity log.

- **GetUsername:**  
  A form that prompts the user for their name at startup, ensuring a personalized experience throughout the session.

- **ActivityLog (static class):**  
  Manages a running log of user actions (e.g., tasks added, quizzes started). The last five actions can be displayed on request, providing transparency and engagement.

### Updated Logic

- **GUI Integration:**  
  The application now launches with a graphical interface for quizzes and task management, enhancing usability and accessibility.

- **Natural Language Task/Reminder Detection:**  
  The chatbot can interpret user input to detect requests for creating tasks or reminders, automatically launching the appropriate form and logging the action.

- **Activity Logging:**  
  All significant user actions (e.g., adding a task, starting a quiz) are recorded. Users can request a summary of recent actions at any time.

- **Personalization and Sentiment Analysis:**  
  The chatbot detects sentiment in user messages (e.g., worry, frustration, curiosity) and responds empathetically. It also remembers user preferences and favorite topics.

- **Enhanced Help and Q&A:**  
  Users can view available questions by category or see all possible questions, making it easier to explore cybersecurity topics.

- **Text-to-Speech Improvements:**  
  All responses, prompts, and feedback can be read aloud, supporting accessibility.

---

## Features

- **Personalized Responses:** The chatbot addresses the user by their name for a more engaging experience.
- **Cybersecurity Education:** Learn about password security, phishing scams, safe browsing, and other cybersecurity topics.
- **Interactive Q&A:** Ask the chatbot questions and receive helpful, context-aware answers.
- **Fun Interactions:** Includes jokes and lighthearted responses to keep the conversation enjoyable.
- **Text-to-Speech Support:** The chatbot can read responses aloud for accessibility (requires enabled audio).
- **Enhanced Help System:** Type `help` at any time to see a list of supported questions and topics.
- **Improved Error Handling:** The chatbot now provides clearer feedback for unrecognized questions or commands.
- **Task and Reminder Management:** Create, view, and manage tasks and reminders through a modern GUI.
- **Mini-Quiz:** Test your cybersecurity knowledge with an interactive quiz.
- **Activity Log:** View a summary of your recent actions and progress.

---

## Prerequisites

- **.NET Framework 4.8:** Ensure you have the .NET Framework 4.8 installed on your system.
- **Visual Studio 2022:** Open the project in Visual Studio for development and debugging.

---

## Installation

1. **Clone the repository:**
   - `git clone https://github.com/VCCT-PROG2A-2025-G1/PROG_6221_ST10438409_Part_2`
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
   - The chatbot will greet you and prompt for your name via a GUI form.
3. **Ask questions:**
   - Type questions about cybersecurity (e.g., "How do I create a strong password?").
   - Type `help` to see a list of supported questions and topics.
   - Type `joke` for a fun interaction.
   - Type `exit` to end the session.
   - Ask to "add a task" or "set a reminder" to use the Task Assistant GUI.
   - Type "quiz" to launch the cybersecurity quiz.
   - Ask to "show log" to view your recent activity.
4. **Text-to-Speech:**
   - If your system supports it, responses will be read aloud for accessibility.

---

## Example Interaction

Chatbot: Hello! Welcome to the Cybersecurity Chatbot. What's your name?  
You: Dylan

Chatbot: Nice to meet you, Dylan! How can I help you today?  
You: How do I create a strong password?

Chatbot: Make sure to use a mix of uppercase and lowercase letters, numbers, and special characters, Dylan. Avoid anything easy to guess like your name or birthday.  
You: add a task to update antivirus

(TaskAssistant_GUI launches for task entry)

You: quiz

(Mini_Quiz_GUI launches for interactive quiz)

You: show log

Chatbot: Here’s a summary of recent actions:  
1. Task Added: update antivirus on 2025/05/30  
2. Quiz Started: Cybersecurity Basics

You: exit

Chatbot: Goodbye Dylan, have a great day!

---

## File Structure

- **Program.cs:** Entry point of the application. Handles user input and chatbot responses, launches forms.
- **ChatbotLogic.cs:** Contains the logic for loading responses, generating answers, and managing tasks, reminders, and activity logs.
- **Resources/Response.json:** Stores predefined chatbot responses categorized by topics.
- **Communication.cs:** Handles text-to-speech and user interaction methods.
- **ConsoleFormat.cs:** Manages console formatting, such as text color and borders.
- **TaskAssistant_GUI.cs:** Windows Form for creating and managing tasks and reminders.
- **DisplayAllTasks.cs:** Windows Form for displaying all saved tasks.
- **Mini_Quiz_GUI.cs:** Windows Form for the interactive cybersecurity quiz.
- **GetUsername.cs:** Windows Form for capturing the user's name.
- **ActivityLog.cs:** Static class for managing and displaying the activity log.

---

## Customization

- **Personalized Responses:** Update the `Response.json` file to include `{UserName}` placeholders for dynamic responses.
- **Add New Topics:** Extend the `Response.json` file with new categories and questions.
- **Modify Appearance:** Customize the console and form styling in `ConsoleFormat.cs` and the respective form classes.
- **Enable/Disable Text-to-Speech:** Adjust settings in `Communication.cs` to control audio output.

---

## Project Overview

This chatbot project demonstrates advanced C# programming, Windows Forms integration, JSON-based data management, and user interface design. The modular structure allows for easy expansion and adaptation to new cybersecurity topics or educational needs. The focus on accessibility, engagement, and practical task management ensures the chatbot is both informative and enjoyable to use.

---