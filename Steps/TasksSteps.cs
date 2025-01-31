using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TodoistTest.Core;
using TodoistTest.Core.Models;

namespace TodoistTest.Steps
{
    [Binding]
    public class TasksSteps: BaseSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public TasksSteps(AppiumContext appiumContext, ScenarioContext scenarioContext) : base(appiumContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I click Quick Add button")]
        public void WhenIClickQuickAddButton()
        {
            todayScreen.GetQuickAddTaskButton().Click();
        }

        [Then(@"I can see Add New Task Dialog")]
        public void ThenICanSeeAddNewTaskDialog()
        {
            Assert.That(todayScreen.GetAddNewTaskDialog().GetTaskTitleTextField().Displayed);
            Assert.That(todayScreen.GetAddNewTaskDialog().GetTaskDescriptionTextField().Displayed);
            Assert.That(todayScreen.GetAddNewTaskDialog().GetSubmitTaskButton().Displayed);
        }

        [When(@"I enter task details")]
        public void WhenIEnterTaskDetails(Table table)
        {
            TodoistTask task = table.CreateInstance<TodoistTask>();
            task.Title = $"{task.Title} [{DateTime.Now}]"; 

            todayScreen.GetAddNewTaskDialog().GetTaskTitleTextField().SendKeys(task.Title);
            todayScreen.GetAddNewTaskDialog().GetTaskDescriptionTextField().SendKeys(task.Description);
            _scenarioContext["CurrentTask"] = task;
        }

        [When(@"I click SubmitTask button")]
        public void WhenIClickSubmitTaskButton()
        {
            todayScreen.GetAddNewTaskDialog().GetSubmitTaskButton().Click();
            appiumContext.Driver.Navigate().Back();
        }

        [Then(@"the new task is created with correct name and description")]
        public void ThenNewTaskIsCreated()
        {
            TodoistTask expectedTask = (TodoistTask)_scenarioContext["CurrentTask"];
            
            Assert.That(todayScreen.GetTask(expectedTask).Displayed, "New task was not created successfully.");
            Assert.That(todayScreen.GetTaskDescription(expectedTask).Text.Equals(expectedTask.Description),
                "New task does not have correct description");

        }

        [When(@"I create a task")]
        public void WhenICreateATask(Table table)
        {
            TodoistTask task = table.CreateInstance<TodoistTask>();
            task.Title = $"{task.Title} [{DateTime.Now}]";

            todayScreen.GetQuickAddTaskButton().Click();
            todayScreen.GetAddNewTaskDialog().GetTaskTitleTextField().SendKeys(task.Title);
            todayScreen.GetAddNewTaskDialog().GetTaskDescriptionTextField().SendKeys(task.Description);
            todayScreen.GetAddNewTaskDialog().GetSubmitTaskButton().Click();
            appiumContext.Driver.Navigate().Back();

            _scenarioContext["CurrentTask"] = task;
        }

        [When(@"I click Complete checkbox")]
        public void AndIClickCompleteCheckbox()
        {
            TodoistTask expectedTask = (TodoistTask)_scenarioContext["CurrentTask"];
            todayScreen.GetCompleteTaskCheckbox(expectedTask).Click();
        }

        [Then(@"newly created task is not displayed in Today screen")]
        public void ThenNewlyCreatedTaskIsNotDisplayedInTodayScreen()
        {
            TodoistTask expectedTask = (TodoistTask)_scenarioContext["CurrentTask"];
            Assert.Throws<NoSuchElementException>(() => todayScreen.GetTask(expectedTask), "New task was not displayed after complete.");
        }
    }
}
