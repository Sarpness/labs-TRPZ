using lab9;

//9//

CurCity city1 = new CurCity();
city1.City = City.getInstance(3);
city1.City.GetInfo();

CurCity city2 = new CurCity();
city2.City = City.getInstance(3);
city2.City.GetInfo();

city2.City.count_ = 5000;

city2.City.GetInfo();



User user1 = new Admin("Админ года");
Console.WriteLine(user1.Name);
UserAction addStaff = user1.Create();

user1 = new Employer("Уже не Админ года");
Console.WriteLine(user1.Name);
UserAction newTask = user1.Create();

user1 = new Visitor("Кого-то уволили((");
Console.WriteLine(user1.Name);
UserAction showList = user1.Create();

//10//

lab9.Task t1 = new lab9.Task(city1.City.id_, 3);
WorkFacade f1 = new WorkFacade(t1, city1.City);

ShowTask prog = new ShowTask();
prog.ActionTask(f1);

//11//

AdminPanel adminPanel = new AdminPanel();
AdminCommand adminCommand = new AdminCommand();
adminPanel.SetCommand(new PanelCommand(adminCommand));

user1 = adminPanel.setUp(user1, "test name");
Console.WriteLine(user1.Name + '\n' + user1.Status + '\n');


user1 = adminPanel.setDown(user1, "test name2");
Console.WriteLine(user1.Name + '\n' + user1.Status + '\n');

user1 = adminPanel.setDown(user1, "test name2");



//12//
