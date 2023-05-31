# Distant Planets Dream Of You Too
### An Interactive Comic that uses OpenCV enabled Webcam Gaze Interaction to explore the large scale implications of Quantum Mechanics

# Rhetorical Analysis
## Idea/Purpose
Our goal was to envision the large-scale implications of findings in the field of quantum mechanics, specifically quantum entanglement, and then communicate that vision to an audience, capitalizing on the strengths and possibilities for communication in our medium. 

## Form
I attempted to envision an approach that would communicate the subtleties of quantum entanglement with interactivity at every turn. Within this experience the user would never be a bystander but always an active participant, always a conscious observer to our little universe. To flip the script on the one-way communication present in comics and have the comic read the user, remember, and react.

## Idiom 
The core idea we wanted to play with came down to; entanglement happens in a chain reaction, affecting one thing to the next, all of it instantaneously. The process of communicating this resulted in the idea that somewhere out there, there is a planet. One that is exactly the planet that you are imagining. Through the process of going through the experience, the concept of that planet gets fleshed out in the user’s mind by keeping track of the different elements they took part in observing. The final purpose of this mechanism is to present the culminating idea of this planet and then reveal that it is just as likely that the idea flowed the other way. That from somewhere out there in the cosmos that idea came to you. You imagined this planet; this planet imagined you.  
I put extra emphasis on making sure that everything should be interactive. There should be something for the user to interact with at every turn. From methods of navigating the experience down to even just reading there is a mechanic that communicates that their interaction with the system changes the system. Some of these interactive communication mechanics include:

### Main Character: 
The main character sprite symbolizes super position, probability clouds, observation effect on a system. The character exists in all panels at the same time but is only seen on the observed panel. When looked at it can either be in spin-up or spin-down state represented by color (cyan, magenta). That state can be changed whenever it is unobserved. Even in the time it takes to blink it can change. In panels that are not observed the character is represented by a squiggly cloud that represents position probability clouds. The character can be in all places at once but is only in the place that the user is looking. 

### Panel Sequence: 
In comic pages the frames observed change how they are revealed to communicate how changes in quantum state occur instantaneously without the passage of time. Some conditions of what you see next are a result of something you did not think correlated. 

### Panels & Page Transitions:
Observation effect is communicated in the transitions between pages. The second page has a door mechanic that attempts to reinforce the awareness of time and sequence to the panels. By first being observed as locked, the user can always see that they have not affected enough panels. The panels change from what they were previously in real time, but the change can only be seen on a second read of the page which unlocks the door. The third page brings attention to the concept that the user, or any observer, anything, has an influence on everything else in the system. The metaphor used, an ecosystem, is strengthened with the page exit mechanic of the beanstalk. The beanstalk rises and falls with the users gaze but can only be climbed after the user observation of all the panels. 

## Structure 
Starting with a radio clock event which is intended as a tutorial on how the face tracking mechanism and requires that the user finds the right frequency on the radio scanner where the song is clear. The user is introduced to the comic that they will be reading and into the first comic page. 
Event scenes are where the player makes the observations that will contribute to the customized planets. To keep the planet mechanism somewhat hidden as well as keep an engaging pace to the experience, event and comic scenes are alternated. Event scenes are designed to operate within the same design philosophy that there should be something for the user to interact with at every turn. 

### First Page:
The first page is an introduction to the page mechanics, main character, and premise, as well as transition to the first event scene. 

### First Event Scene: 
The first event scene is a race between 4 ducks. The outcome of the race determines the primary and secondary color of the eventual resulting planet. If a duck is being observed, it will move quicker than the other ducks affecting the results. In this way the user has a hand in altering the outcome of the event. The intention here is to be subtle in the user’s awareness to their effect. The user is then presented with a photo of the first and second place ducks to reinforce the user’s awareness of the outcome, that the game keeps track, and that the information will be used later. 

### Second Page:
The second page intends to introduce the user to the concept that time and sequence are non-linear when considering quantum mechanics. And the idea of instantaneousness. 

### Second Event Scene:
The second event scene displays three planet shapes, one of which will be the user’s choice by observation. Once again, leaning into the user’s unawareness of the importance and displayed as a gallery. An observed planet will orbit to the front to be viewed better and the planet that is observed for a certain amount of time will be selected. 

### Third Page:
The third page intends to communicate the user’s role within the system and allude to a grand idea of an intertwined universal experience shared by all things in existence, using an ecosystem as a metaphor device.

### Third Event Scene:
The third event scene places the user on the surface of their imagined planet and displays creatures that inhabit it. When the user looks at the creatures, an associated instrument is added to the song until the whole song is revealed. It’s at this moment when the camera pulls back and reveals to them the planet that their observations constructed. “Do You Dream of Distant Planets?”

## Craft 
The core mechanic (gaze estimation) was a large part of what I spent this semester developing. I had originally started with making a python program that used OpenCV and models from Google’s MediaPipe Face Landmarker that would track the pupil in relation to the eye. After getting a prototype working, I ran into a few issues. First being that the control was much too jumpy and unpredictable and second being that it became a monumental task to get python scripts to run at runtime in Unity. Because of this, I pivoted to using an asset that ports the OpenCV library into Unity C#. There were examples included that demonstrated a VTuber and a face filter usage using a face model from Dlib Face Landmarker. I was able to take elements from these examples to get head position data for each processed frame. I used that position data and stabilized the raw input and used the resulting data to position the camera. Interactions with the rest of the program are then variations of raycast methods to interact with on screen content. The result was a very VR-esque gaze interaction, and I leaned into that with the development of the rest of the project. 

## Surface 
For the music in the game, I repurposed an old song that I had made with various instruments. I had three variations of the loop, a verse, chorus, and a chorus with a vocal type of melody. I wanted to use the verse parts on the comic pages and the chorus on the event sequences. I created a method of switching parts at the correct beat count so that it would be a continuous dynamic song. Other audio related stuff I did was activating each instrument in the song according to a raycast interaction with the creatures on the planet and recording all the other sound effects in the project.
As I was assembling the project I constantly iterated on the appearance of the game and modified the assets that I collected from my group to all fit cohesively together. I focused on making a paper cut-out style to gravitate towards with all of the assets in order to fit within the purposed comic book style. I used post-processing effects tuned to each section to help with visual presentation and make everything gel. Comic panels were a mix of interactions to give the effect of focused vision and peripheral, which served a dual purpose of indicating to the user where they were looking within the game.

## Personal Role 
The roles I took on in this project include Scrum Leader, Gameplay & UX Designer, Lead Programmer, Audio/ Music. Within these roles I built my skills concepting a vision, organizing tasks for my team, creating cohesion between assets submitted by my team, and using programing with intent to effectively communicate complex ideas to an audience. 

## What I Learned
I learned a lot about what I could do better from a leadership perspective. First being that a storyboard, early in the process, is essential for getting everybody on the same page with a clear goal in mind. With complex ideas, words don’t quite do an idea justice and leave a lot to be desired in communication. I started early on with making tutorial videos for my team on how to interact with functions that I had scripted and how to use them for things they would like to add. Unfortunately, I hadn’t gotten anyone to use them to contribute directly to the project. I am learning as I go and often the development course I take is confusing to others. The next time I am in a similar position, I am going to make an effort to make everything as accessible as possible within the design of my mechanics.
I also learned a lot in the way of UX design as this new way of navigating a game needed to be intuitive to work with. It required me to think about every decision I made in order to optimize the experience and avoid any implementations that were confusing, frustrating, or detracted from the experience. I had a lot of people play through the experience during development and made note of where any potential hangups were and improved on them throughout development.

# Comments from Program Director and Professor, Dr. Anthony Ellertson
Best of show for all the reasons I have discussed in the past with the group. I know from the RA's that some of the visual elements couldn't make it into the last build.  I encourage the group to revisit and polish the project as much as possible.  Submit this to contests like I have discussed.  It is a portfolio artifact not only in its conception and design (this is the best interactive metaphor I have seen for quantum principles), but the group also overcame difficulties to shine.  You will jobs based on this project alone. 
