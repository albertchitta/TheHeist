// See https://aka.ms/new-console-template for more information

using TheHeist.Models;

var title = $@"
 _______   __                            __      __                                    __    __            __              __     
|       \ |  \                          |  \    /  \                                  |  \  |  \          |  \            |  \    
| $$$$$$$\| $$  ______   _______         \$$\  /  $$______   __    __   ______        | $$  | $$  ______   \$$  _______  _| $$_   
| $$__/ $$| $$ |      \ |       \         \$$\/  $$/      \ |  \  |  \ /      \       | $$__| $$ /      \ |  \ /       \|   $$ \  
| $$    $$| $$  \$$$$$$\| $$$$$$$\         \$$  $$|  $$$$$$\| $$  | $$|  $$$$$$\      | $$    $$|  $$$$$$\| $$|  $$$$$$$ \$$$$$$  
| $$$$$$$ | $$ /      $$| $$  | $$          \$$$$ | $$  | $$| $$  | $$| $$   \$$      | $$$$$$$$| $$    $$| $$ \$$    \   | $$ __ 
| $$      | $$|  $$$$$$$| $$  | $$          | $$  | $$__/ $$| $$__/ $$| $$            | $$  | $$| $$$$$$$$| $$ _\$$$$$$\  | $$|  \
| $$      | $$ \$$    $$| $$  | $$          | $$   \$$    $$ \$$    $$| $$            | $$  | $$ \$$     \| $$|       $$   \$$  $$
 \$$       \$$  \$$$$$$$ \$$   \$$           \$$    \$$$$$$   \$$$$$$  \$$             \$$   \$$  \$$$$$$$ \$$ \$$$$$$$     \$$$$ 
";
Console.WriteLine(title);

var question1 = "Enter team member name:";
Console.WriteLine(question1);
var name = Console.ReadLine();

bool successful = false;
int parsedSkill = 0;
decimal parsedCourage = 0;
Team team = new Team();

while (name != "")
{
    while (!successful)
    {
        Console.WriteLine($"Enter {name}'s skill level:");
        var skill = Console.ReadLine(); //"1"
        //try parse - 1. returns a bool whether it succeeded or not 2.
        successful = int.TryParse(skill, out parsedSkill);
    }
    successful = false;

    while (!successful)
    {
        Console.WriteLine($"Enter {name}'s courage factor:");
        var courage = Console.ReadLine();
        successful = decimal.TryParse(courage, out parsedCourage);
    }
    successful = false;

    var teamMember = new TeamMember(name, parsedSkill, parsedCourage);
    team.AddMember(teamMember);

    Console.WriteLine();
    Console.WriteLine(question1);
    name = Console.ReadLine();
}

Console.WriteLine($@"
        TEAM
     {team.Members.Count} member(s)
--------------------");
team.Members.ForEach(member => member.Print());

int difficultyLevel = 100;
int teamSkillLevel = 0;

team.Members.ForEach(member =>
    {
        teamSkillLevel += member.SkillLevel;
    }  
);

Console.WriteLine($@"Team Skill Level: {teamSkillLevel}");
if (teamSkillLevel >= difficultyLevel)
{
    Console.WriteLine("Mission Success!");
}
else
{
    Console.WriteLine("Mission Failed!");
}