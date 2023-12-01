Feature: UI Avaloq Login
  This is the POC for Avaloq UI Automation

  Background: Start Application
    When I start Avaloq UI Application 'tabs02'

  Scenario: Login Successful
    Given I enter user 'racetest'
    And password 'racetest99'
    When I click on the log in button
    Then The login is successful

  Scenario: Login Failed
    Given I enter user 'a'
    And password 'b'
    When I click on the log in button
    Then The login fails