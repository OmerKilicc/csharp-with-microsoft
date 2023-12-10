int examCount = 5;
int extraPointModifier = 10;

string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan" };

int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };

int[] studentScores = new int[10];

string letterGrade = "";

// display the header row for scores/grades
Console.Clear();
Console.WriteLine("Student\t\tExam Score\tOverall Grade\tExtra Credit\n");


foreach (string name in studentNames)
{
    string currentStudent = name;

    if (currentStudent == "Sophia")
        studentScores = sophiaScores;

    else if (currentStudent == "Andrew")
        studentScores = andrewScores;

    else if (currentStudent == "Emma")
        studentScores = emmaScores;

    else if (currentStudent == "Logan")
        studentScores = loganScores;

    int sumExamScores = 0;
    int sumExtraScores = 0;

    decimal averageExamScore = 0;
    decimal averageExtraScore = 0;
    decimal finalScore = 0;
    decimal extraPointsEarned = 0;

    int divider = extraPointModifier * examCount;

    int gradedAssignmentsCounter = 0;
    /* 
    the inner foreach loop sums assignment scores
    extra credit assignments are worth 10% of an exam score
    */
    foreach (int score in studentScores)
    {
        gradedAssignmentsCounter += 1;

        if (gradedAssignmentsCounter <= examCount)
            sumExamScores += score;

        else
            sumExtraScores += score;
    }


    averageExamScore = (decimal)sumExamScores / examCount;
    averageExtraScore = (decimal)sumExtraScores / (gradedAssignmentsCounter - examCount);
    finalScore = (decimal)((decimal)((decimal)sumExtraScores/extraPointModifier) + sumExamScores) / examCount;
    extraPointsEarned = (decimal)sumExtraScores / divider;


    if (finalScore >= 97)
        letterGrade = "A+";

    else if (finalScore >= 93)
        letterGrade = "A";

    else if (finalScore >= 90)
        letterGrade = "A-";

    else if (finalScore >= 87)
        letterGrade = "B+";

    else if (finalScore >= 83)
        letterGrade = "B";

    else if (finalScore >= 80)
        letterGrade = "B-";

    else if (finalScore >= 77)
        letterGrade = "C+";

    else if (finalScore >= 73)
        letterGrade = "C";

    else if (finalScore >= 70)
        letterGrade = "C-";

    else if (finalScore >= 67)
        letterGrade = "D+";

    else if (finalScore >= 63)
        letterGrade = "D";

    else if (finalScore >= 60)
        letterGrade = "D-";

    else
        letterGrade = "F";

    // Student         Grade
    // Sophia:         92.2    A-

    Console.WriteLine($"{currentStudent}\t\t{averageExamScore}\t\t{finalScore}\t{letterGrade}\t{averageExtraScore} ({extraPointsEarned} pts)");
}

// required for running in VS Code (keeps the Output windows open to view results)
Console.WriteLine("\n\rPress the Enter key to continue");
Console.ReadLine();
