//------------------------------------------------------------------------------------------------------------------//
// Name: Dylan Shortt
// Group: 1
// Student Number: ST-10438409
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// Reference: 
// GitHub Copilot. (2025). AI programming assistant. [online] Available at: https://copilot.github.com/ [Accessed: 2025].
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// <summary>
// These import statements are used to import the necessary libraries for the program to run.
// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// <summary>
// The namespace is used to group classes that are logically related.
// </summary>
namespace PROG_6221_ST10438409_Part_1
{
    //------------------------------------------------------------------------------------------------------------------//
    // <summary>
    // This class represents a mini quiz application.
    // </summary>
    internal class MiniQuiz
    {
        //-------------------------------------------------//
        // Declaration of variables
        private string question;
        private string answer_A;
        private string answer_B;
        private string answer_C;
        private string answer_D;
        private string correctAnswer;
        private string explanation;
        //-------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Defualt constructor for the MiniQuiz class 
        // </summary>
        public MiniQuiz()
        {

        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Constructor for the MiniQuiz class that initializes the quiz question and answers.
        // </summary>
        public MiniQuiz(string question, string answer_A, string answer_B, string answer_C, string answer_D, string correctAnswer, string explanation)
        {
            this.question = question;
            this.answer_A = answer_A;
            this.answer_B = answer_B;
            this.answer_C = answer_C;
            this.answer_D = answer_D;
            this.correctAnswer = correctAnswer;
            this.explanation = explanation;
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Returns correct answer for the quiz.
        // </summary>
        public string GetCorrectAnswer()
        {
            //-------------------------------------------------//
            // Return the correct answer for the quiz
            return correctAnswer;
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Gets the explanation for the quiz question.
        // </summary>
        public string GetExplanation()
        {
            return explanation;
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Gets the question of the quiz.
        // </summary>
        public string GetQuestionForQuiz()
        {
            //-------------------------------------------------//
            //Declare a string variable to store the question, plus the first 4 answers
            string quizQuestion = $"Question:\n{question}\n\nA: {answer_A}\n\nB: {answer_B}\n\nC: {answer_C}\n\nD: {answer_D}"; ;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // if C and D are empty, then only return A and B
            if (string.IsNullOrEmpty(answer_C) && string.IsNullOrEmpty(answer_D))
            {
                quizQuestion = $"Question:\n{question}\n\n1. {answer_A}\n\n2. {answer_B}";
            }

            //-------------------------------------------------//
            // Return the quiz question
            return quizQuestion;
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//
    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//