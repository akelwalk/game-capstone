This will explain how to implement the transitions. There's only a couple things you need to do.

1. Drag the 'transition' prefab into your scene. Make sure to click on it and see that the 'transitionDirection' boolean in the 'transitionSmooth' is not checked / false.

=====

2. In your main script where you change scenes, add this line:

    [SerializeField] GameObject transitionObject;

Then, in the Unity Inspector, set this GameObject to the 'transition' prefab you previously dragged into the scene.

=====

3. In at the actual location where you want to change scenes (i.e. the place that says 'Scenemanager.LoadScene(#);), replace it with one of these lines:

    transitionObject.GetComponent<transitionSmooth>().transitionStart(true, #);
    transitionObject.GetComponent<transitionSmooth>().transitionStart(true, "NAME");


=====

I think this should work for whatever you need, BUT I know the CoffeeShop scene is a little strange because of the UI elements and the scene reloading, so there might be a little more trouble with that one. On Sunday, if you're able to make the call, and need more help integrating any part of my stuff, I'll help however I can.


=====


Other thing:


I have a function in the rhythm minigame called 'public void startRhythm(int rhythmTrack)' in a script called 'beginRhythm'. I'm wasn't sure exactly how you wanted to integrate this, but just use this function to start the rhythm minigame and choose the specific track you want. Otherwise, the buttons just pop up like how I've showed in our presentations.