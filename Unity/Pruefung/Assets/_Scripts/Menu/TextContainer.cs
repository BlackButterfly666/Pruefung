using UnityEngine;

public class TextContainer : MonoBehaviour
{
	//Text for Story
	[TextArea] public string text01; //Deep Dark
	[TextArea] public string text02;
	[TextArea] public string text03; //Wagner
	[TextArea] public string text04; //The fairy loretta
	[TextArea] public string text05;
	[TextArea] public string text06; //Wagner with the fairy
	[TextArea] public string text07;
	[TextArea] public string text08; //The way out
	[TextArea] public string text09;
	[TextArea] public string text10;
	[TextArea] public string text11; //Wagners/Players Task
	[TextArea] public string text12; //Epilog-Text

	public void Awake()
	{
		text01 = "The Deep Dark. This world is pure black. It is empty. It seems that there is only void. ";
		text02 = "But that is not true, as there is a whole world, but without any colour, so nobody is able to see. ";
		text03 = "Wagner is a little demon who lives in a book, somewhere in the Deep Dark. His world is dark and he is lonely.";
		text04 = "Someday a vibrant shining fairy appears at Wagners home. She got lost on her way to find her husband Stan. ";
		text05 = "In another dimension she bought a box of cigars for him and took the wrong route, so she ended up in the Deep Dark.";
		text06 = "Wagner meets her and is curious about the wonderful colours she emits. He wishes to be able to emit the same nice colours. ";
		text07 = "So in exchange for a way out of this place, she proposed him to fulfill his wish. And so they did. ";
		text08 = "Wagner is teleported to a small place, where some things can be seen and it’s not as dark and black anymore. ";
		text09 = "The fairy finds her way home, but before she is gone, she tells Wagner the way to “White Light”.";
		text10 = "So Wagner goes on his journey and searches for the colours. ";
		text11 = "He is heading through “The Between” and collects every single Colourdrop in each region of this slightly scary world.";
		text12 = "Then he notices a vibrant white shining door or maybe something more like a rift in space. By entering this rift he leaves “The Between” and enters “The White Light”. Everything is exceptionally vibrant, peaceful and happy here. Wagner feels more blessed and cheerful than he ever was.";
	}
}
