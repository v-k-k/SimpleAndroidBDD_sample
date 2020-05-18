# Created by vkryshtop at 04.04.2020
Feature: Test main functions
  # Enter feature description here

  Background:
    Given Tap on 'Settings' button, make sound louder and check if it was really done
    When click 3 times on break seconds tap on 'Add to favorites'

  @smoke
  Scenario: After clicking on "Add to favorites" button user will see the correct placeholder text
    Then New window contains the Please enter the title. placeholder

  @regression
  Scenario: Check if App info contains correct title
    Then Send Hey, hello!!! and check if app info contains BoxingTimer in window title
    And System info contains BoxingTimer in app title

  @ad-hoc
  Scenario: Check if saved settings are displayed in "Favorites" window
    Then Saved settings contains Hey, hello!!! in title
    And training time is 03:00
    And break time is 01:00 after 3 clicks
