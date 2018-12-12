using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextContainer : MonoBehaviour
{
	//Text for Story
	[TextArea] public string text01; //Deep Dark
	[TextArea] public string text02; //Wagner
	[TextArea] public string text03; //The fairy loretta
	[TextArea] public string text04; //Wagner with the fairy
	[TextArea] public string text05; //The way out
	[TextArea] public string text06; //Wagners/Players Task
	[TextArea] public string text07; //Epilog-Text

	public void Awake()
	{
		text01 = "This world is pure black. It is empty. It seems that there is only void, but that is not true, as there is a whole world, but without any colour, so nobody is able to see. ";
		text02 = "Wagner is a little demon who lives in a book, somewhere in the Deep Dark. His world is dark and he is lonely.";
		text03 = "Someday a vibrant shining fairy appears at Wagners home. She got lost on her way to find her husband Stan. In another dimension she bought a box of cigars for him and took the wrong route, so she ended up in the Deep Dark.";
		text04 = "Wagner meets her and is curious about the wonderful colours she emits. He wishes to be able to emit the same nice colours. So in exchange for a way out of this place, she proposed him to fulfill his wish. And so they did. ";
		text05 = "Wagner is teleported to a small place, where some things can be seen and it’s not as dark and black anymore. The fairy finds her way home, but before she is gone, she tells Wagner the way to “White Light”.";
		text06 = "So Wagner goes on his journey in search for the colours. He is heading through “The Between” and collects every single Colourdrop in each region of this slightly scary world.";
		text07 = "Then he notices a vibrant white shining door or maybe something more like a rift in space. By entering this rift he leaves “The Between” and enters “The White Light”. Everything is exceptionally vibrant, peaceful and happy here. Wagner feels more blessed and cheerful than he ever was.";
	}
}
