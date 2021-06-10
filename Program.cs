using NUnit.Framework;
using NUnit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using System;

[TestFixture]
public class TestProgram
{
    private IWebDriver driver;
   
    [SetUp]
    public void SetupTest()
    {
        // change this path
        driver = new ChromeDriver("/Users/dimas/Works/XMileComputer/libs/driver");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6000);
        driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";
        
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    [Test]
    /**
    * Verify Click OK Alert
    */
    public void TestOKAlert()
    {
        IWebElement btn_Alert = driver.FindElement(By.XPath("//button[text()='Click for JS Alert']"));
        btn_Alert.Click();
        
        var alert_Dialog = driver.SwitchTo().Alert();
        alert_Dialog.Accept();
        
        IWebElement message_Result= driver.FindElement(By.Id("result"));
        Assert.AreEqual("You successfully clicked an alert" , message_Result.Text);
    }

    [Test]
    /**
    * Verify Click Cancel Confirm
    */
    public void TestCancelConfirmAlert()
    {
        IWebElement btn_Alert = driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']"));
        btn_Alert.Click();
        
        var alert_Dialog = driver.SwitchTo().Alert();
        alert_Dialog.Dismiss();
        
        IWebElement message_Result= driver.FindElement(By.Id("result"));
        Assert.AreEqual("You clicked: Cancel" , message_Result.Text);
    }

    [Test]
    /**
    * Verify Click OK Confirm
    */
    public void TestOKConfirmAlert()
    {
        IWebElement btn_Alert = driver.FindElement(By.XPath("//button[text()='Click for JS Confirm']"));
        btn_Alert.Click();
        
        var alert_Dialog = driver.SwitchTo().Alert();
        alert_Dialog.Accept();
        
        IWebElement message_Result= driver.FindElement(By.Id("result"));
        Assert.AreEqual("You clicked: Ok" , message_Result.Text);
    }

    [Test]
    /**
    * Verify fill data on dialog confirmation
    */
    public void TestFillDataDialogAlert()
    {
        IWebElement btn_Alert = driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']"));
        btn_Alert.Click();
        
        var alert_Dialog = driver.SwitchTo().Alert();
        alert_Dialog.SendKeys("TEST");
        alert_Dialog.Accept();
        
        IWebElement message_Result= driver.FindElement(By.Id("result"));
        Assert.AreEqual("You entered: TEST" , message_Result.Text);
    }

    [Test]
    /**
    * Verify cancel fill data on dialog confirmation
    */
    public void TestCancelFillDataDialogAlert()
    {
        IWebElement btn_Alert = driver.FindElement(By.XPath("//button[text()='Click for JS Prompt']"));
        btn_Alert.Click();
        
        var alert_Dialog = driver.SwitchTo().Alert();
        alert_Dialog.SendKeys("TEST");
        alert_Dialog.Dismiss();
        
        IWebElement message_Result= driver.FindElement(By.Id("result"));
        Assert.AreEqual("You entered: null" , message_Result.Text);
    }

    
}