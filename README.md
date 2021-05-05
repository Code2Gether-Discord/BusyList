# BusyList

## How to contribute
1. Clone the project (press the big green button then open in visual studio)
2. Decide what feature you want to implement. Check out Issues here on github and see if you find something, otherwise create your own issue. When you enter a issue and look to your right you can press "Assign to yourself" so that no one else also works on the same issue
3. Go back to visual studio and look at the bottom to the right where it says: "master" and click on that then New Branch
4. Name the branch using this format: feature/issueNumber-title replace issuenumber with the number on the issue and title with something explanatory
5. Make some changes in visual studio and look to the bottom right again then click on the Pencil (there will be a number of how many changes has been done). Now you can either view changes you have made by clicking on the files, right click and remove or commit and push. Remember to write what you have actually done in the message.
6. If you have pushed the changes to github you can now create a Pull request. Go to pull requests and click New Pull Request. You will see the master branch on the left side (thats the branch we will merge in to) and on the right side you have to pick your branch. 
7. In the message you can write closes #issueNumber (replace issuenumber with your issue number) which will automatically close the issue you picked whenever the pull request has been merged. Then we are all set and you can click on Create Pull Request. 
8. Now you can ask people to review it since we always want at least 2 people to view the pull request before merging it. Be ready to recieve some feedback! It will help you improve and learn new things.

### Parsing information
The following resources might be very useful if you want to experiment with the parser
* [Sprache](https://github.com/sprache/Sprache) 
* https://nblumhardt.com/2010/01/building-an-external-dsl-in-c/
* https://justinpealing.me.uk/post/2020-03-11-sprache1-chars/