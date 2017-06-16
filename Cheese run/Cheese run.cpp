/*
	author: S. M. Shahriar Nirjon
	last modified: August 8, 2008
*/
# include "iGraphics.h"
# include <stdio.h>
# include <stdlib.h>
# include <time.h>

struct cat_pos
{
	int x,y;

}danger[3],diff[3],trapxy[3];

int scores[5], menu_x, menu_y, jerry_x, jerry_y, cheese_x, cheese_y;
int phase, num, d, jd, length, i, score, catno, typed, indx, eat, timer=0, trap;

char names[5][21];
char show[6][80];
unsigned char movement;

bool read,start,gameon, high, special, confirm;
bool eaten,cheese_create,cat_create, trap_create;

FILE *from;

//to show the current score

void traptimer()
{
	if (gameon) trap--;
}

void timerlength()
{
	if (gameon) length--;
}

void timerreducer()
{
	if (gameon) timer--;
}

void score_show()
{
	iSetColor(255,255,255);
	char str[11];
	sprintf(str,"%d",score);
	iText(65,55,str,GLUT_BITMAP_TIMES_ROMAN_24);
}

//change the co ordinate of the cats
void changecourse(int i)
{
	int r;
	
	if (phase==5) { d=2+(score/200); jd=6+(score/200); }
	if (phase==6) { d=2+(score/250); jd=6+(score/250); }
	if (phase==7) { d=2+(score/300); jd=6+(score/300); }

	if (d>=5) d=5;
	
	if (danger[i].x<=0 && danger[i].y<=100)
	{
		int dx[]={d,0,d};
		int dy[]={0,d,d};
		r=rand()%3;

		diff[i].x=dx[r];
		diff[i].y=dy[r];
	}
	else if (danger[i].x<=0 && danger[i].y>=568)
	{
		int dx[]={d,0,d};
		int dy[]={0,-d,-d};
		r=rand()%3;

		diff[i].x=dx[r];
		diff[i].y=dy[r];
	}
	else if (danger[i].x>=768 && danger[i].y<=100)
	{
		int dx[]={-d,0,-d};
		int dy[]={0,d,d};
		r=rand()%3;

		diff[i].x=dx[r];
		diff[i].y=dy[r];
	}
	else if (danger[i].x>=768 && danger[i].y>=568)
	{
		int dx[]={-d,0,-d};
		int dy[]={0,-d,-d};
		r=rand()%3;

		diff[i].x=dx[r];
		diff[i].y=dy[r];
	}
	else if ( (danger[i].x==150 || danger[i].x==300 || danger[i].x==450 || danger[i].x==600) && danger[i].y>=568)
	{
		int dx[]={-d,d,0,-d,d};
		int dy[]={0,0,-d,-d,-d};
		r=rand()%5;

		diff[i].x=dx[r];
		diff[i].y=dy[r];
	}
	else if ( (danger[i].x==150 || danger[i].x==300 || danger[i].x==450 || danger[i].x==600) && danger[i].y<=100)
	{
		int dx[]={-d,d,0,-d,d};
		int dy[]={ 0,0,d, d,d};
		r=rand()%5;

		diff[i].x=dx[r];
		diff[i].y=dy[r];
	}
	else if ( danger[i].x<=0 && (danger[i].y==150 || danger[i].y==250 || danger[i].y==350 || danger[i].y==450) )
	{
		int dx[]={d, 0,0,d, d};
		int dy[]={0,-d,d,d,-d};
		r=rand()%5;

		diff[i].x=dx[r];
		diff[i].y=dy[r];
	}
	else if ( danger[i].x>=768 && (danger[i].y==150 || danger[i].y==250 || danger[i].y==350 || danger[i].y==450) )
	{
		int dx[]={-d, 0,0,-d,-d};
		int dy[]={ 0,-d,d, d,-d};
		r=rand()%5;

		diff[i].x=dx[r];
		diff[i].y=dy[r];
	}
}

void changing()
{
	if (gameon)
	{
		for (int i=0; i<catno; i++)
		{
			danger[i].x+=diff[i].x;
			danger[i].y+=diff[i].y;

			if (danger[i].x<0 || danger[i].x>768 || danger[i].y<100 || danger[i].y>568)
			{
				diff[i].x*=-1;
				diff[i].y*=-1;
				danger[i].x+=diff[i].x;
				danger[i].y+=diff[i].y;
			}
		}
	}
}

void trapshow()
{
	if (!trap_create)
	{
		if (phase==6)
		{
			trapxy[0].x=rand()%768;
			trapxy[0].y=rand()%468+100;
				
			if (!( (jerry_x>=trapxy[0].x && jerry_x<=trapxy[0].x+32) || (jerry_x+32>=trapxy[0].x && jerry_x+32<=trapxy[0].x+32) ))
				if (!( (jerry_y>=trapxy[0].y && jerry_y<=trapxy[0].y+32) || (jerry_y+32>=trapxy[0].y && jerry_y+32<=trapxy[0].y+32) ))
				{
					trap_create=true;
					trap=5-(score/250);
				}

			if (( (cheese_x>=trapxy[0].x && cheese_x<=trapxy[0].x+32) || (cheese_x+32>=trapxy[0].x && cheese_x+32<=trapxy[0].x+32) ))
				if (( (cheese_y>=trapxy[0].y && cheese_y<=trapxy[0].y+32) || (cheese_y+32>=trapxy[0].y && cheese_y+32<=trapxy[0].y+32) ))
					trap_create=false;
		}
		else if (phase==7)
		{
			for (int i=0; i<3; )
			{
				trapxy[i].x=rand()%768;
				trapxy[i].y=rand()%468+100;
				
				if (!( (jerry_x>=trapxy[i].x && jerry_x<=trapxy[i].x+32) || (jerry_x+32>=trapxy[i].x && jerry_x+32<=trapxy[i].x+32) ))
					if (!( (jerry_y>=trapxy[i].y && jerry_y<=trapxy[i].y+32) || (jerry_y+32>=trapxy[i].y && jerry_y+32<=trapxy[i].y+32) ))
					{
						trap_create=true;
						trap=5-(score/300);
					}

				if ((cheese_x>=trapxy[i].x && cheese_x<=trapxy[i].x+32) || (cheese_x+32>=trapxy[i].x && cheese_x+32<=trapxy[i].x+32))
					if ((cheese_y>=trapxy[i].y && cheese_y<=trapxy[i].y+32) || (cheese_y+32>=trapxy[i].y && cheese_y+32<=trapxy[i].y+32))
						trap_create=false;

				if (trap_create) i++;
			}
		}

		if (trap<=2) trap=2;
	}
	else
	{
		iResumeTimer(3);
		
		if (phase==6)
			iShowBMP(trapxy[0].x,trapxy[0].y,"Menu\\trap.bmp");
		else if (phase==7)
			for (int i=0; i<3; i++)
				iShowBMP(trapxy[i].x,trapxy[i].y,"Menu\\trap.bmp");
	}

	if (trap<=0)
	{
		trap=0;
		trap_create=false;
	}
}

//show the cat images
void catshow()
{
	if (!cat_create)
	{
		int cx[]={0,0,768,768};
		int cy[]={100,568,100,568};

		int r=rand()%4;
		danger[0].x=cx[r];
		danger[0].y=cy[r];

		r=rand()%4;
		danger[1].x=cx[r];
		danger[1].y=cy[r];

		cat_create=true;
	}
	else
	{
		if (gameon)
			for (int i=0; i<catno; i++)
				changecourse(i);
	}

	for (int i=0; i<catno; i++)
		iShowBMP(danger[i].x,danger[i].y,"Menu\\tom.bmp");
}

//to show the cheese images
void cheeseshow()
{
	while (!cheese_create)
	{
		cheese_x=rand()%768;
		cheese_y=rand()%468+100;
		
		if (!( (jerry_x>=cheese_x && jerry_x<=cheese_x+32) || (jerry_x+32>=cheese_x && jerry_x+32<=cheese_x+32) ))
			if (!( (jerry_y>=cheese_y && jerry_y<=cheese_y+32) || (jerry_y+32>=cheese_y && jerry_y+32<=cheese_y+32) ))
			{
				cheese_create=true;
				eaten=false;
			}

		for (int i=0; i<catno; i++)
			if ( (cheese_x>=danger[i].x && cheese_x<=danger[i].x+32) || (cheese_x+32>=danger[i].x && cheese_x+32<=danger[i].x+32) )
				if ( (cheese_y>=danger[i].y && cheese_y<=danger[i].y+32) || (cheese_y+32>=danger[i].y && cheese_y+32<=danger[i].y+32) )
				{
					cheese_create=false;
					eaten=true;
				}
	}

	if (!eaten && eat==5)
	{
		special=true;
		timer=10;
		eat=0;
		length=90;
	}

	if (special) iResumeTimer(2);
	else		 iPauseTimer(2);

	if (timer<=0) timer=0;
	if (length<=0) length=0;
	char str[10];	sprintf(str,"%d",timer);

	iSetColor(0,255,0);
	iText(350,40,str,GLUT_BITMAP_TIMES_ROMAN_24);
	
	iSetColor(255,0,0);
	iFilledRectangle(312,65,length,10);
	
	if (!eaten)
	{
		if (special && timer)	iShowBMP(cheese_x,cheese_y,"Menu\\sp_cheese.bmp");
		else					iShowBMP(cheese_x,cheese_y,"Menu\\cheese.bmp");
	}
	else
		cheese_create=false;

	if (special && timer) iResumeTimer(1);
	else				  iPauseTimer(1);
}

//to check if the cheese is eaten
void eatcheck()
{
	if ( (jerry_x>=cheese_x && jerry_x<=cheese_x+32) || (jerry_x+32>=cheese_x && jerry_x+32<=cheese_x+32) )
		if ( (jerry_y>=cheese_y && jerry_y<=cheese_y+32) || (jerry_y+32>=cheese_y && jerry_y+32<=cheese_y+32) )
		{
			eaten=true;
			
			if (phase==5)
			{
				if (special) { score+=(15*timer); eat=0; special=false; timer=length=0; }
				else		 { score+=10; eat++; }
			}
			else if (phase==6)
			{
				if (special) { score+=(25*timer); eat=0; special=false; timer=length=0; }
				else		 { score+=20; eat++; }
			}
			else if (phase==7)
			{
				if (special) { score+=(35*timer); eat=0; special=false; timer=length=0; }
				else		 { score+=30; eat++; }
			}

		}
}

void gameovercheck()
{
	for (int i=0; i<catno; i++)
		if ( (jerry_x>=danger[i].x && jerry_x<=danger[i].x+32) || (jerry_x+32>=danger[i].x && jerry_x+32<=danger[i].x+32) )
			if ( (jerry_y>=danger[i].y && jerry_y<=danger[i].y+32) || (jerry_y+32>=danger[i].y && jerry_y+32<=danger[i].y+32) )
			{
				read=false;
				high=false;
				sprintf(show[5],"Your score is = %d",score);
				phase=8;
				break;
			}

	if (phase==6)
		if ( (jerry_x>=trapxy[0].x && jerry_x<=trapxy[0].x+32) || (jerry_x+32>=trapxy[0].x && jerry_x+32<=trapxy[0].x+32) )
			if ( (jerry_y>=trapxy[0].y && jerry_y<=trapxy[0].y+32) || (jerry_y+32>=trapxy[0].y && jerry_y+32<=trapxy[0].y+32) )
			{
				read=false;
				high=false;
				sprintf(show[5],"Your score is = %d",score);
				phase=8;
			}

	else if (phase==7)
		for (int i=0; i<3; i++)
			if ( (jerry_x>=trapxy[i].x && jerry_x<=trapxy[i].x+32) || (jerry_x+32>=trapxy[i].x && jerry_x+32<=trapxy[i].x+32) )
				if ( (jerry_y>=trapxy[i].y && jerry_y<=trapxy[i].y+32) || (jerry_y+32>=trapxy[i].y && jerry_y+32<=trapxy[i].y+32) )
				{
					read=false;
					high=false;
					sprintf(show[5],"Your score is = %d",score);
					phase=8;
					break;
				}
}

void game_over()
{
	iShowBMP(0,0,"Menu\\rip.bmp");
	iSetColor(0,0,0);
	iText(200,300,show[5],GLUT_BITMAP_TIMES_ROMAN_24);
	iShowBMP(672,0,"Menu\\continue.bmp");

	if (!read)
	{
		if ( ( from = fopen( "High Score\\highscore.txt" , "r" ) ) == NULL)
		{
			from = fopen( "High Score\\highscore.txt" , "w" );
		
			for (int i=0; i<5; i++)
			{
				strcpy(names[i],"Unknown");
				scores[i]=0;
				fprintf( from, "%s %d\n" , names[i] , scores[i] );
			}

			fclose(from);
		}

		from = fopen( "High Score\\highscore.txt" , "r" );

		i=0;

		while (!feof(from))
		{
			fscanf(from,"%s %d",&names[i],&scores[i]);
			i++;
		}

		fclose(from);
		
		read=true;

		for (i=0; i<5; i++)
			if (score>scores[i])
			{
				indx=i;
				
				for (int j=4; j>i; j--)
				{
					strcpy(names[j],names[j-1]);
					scores[j]=scores[j-1];
				}

				scores[i]=score;
				high=true;
				break;
			}
	}

	if (high)
	{
		iText(130,200,"Congrats,New highscore achieved",GLUT_BITMAP_TIMES_ROMAN_24);
		
		if (menu_x>=682 && menu_x<=792 && menu_y>=12 && menu_y<=110)
		{
			typed=0;
			show[5][0]='\0';
			phase=9;
		}
	}
	else
	{
		if (menu_x>=682 && menu_x<=792 && menu_y>=12 && menu_y<=110)
			phase=1;
	}
}

void highscoreset()
{
	iSetColor(240,240,240);
	iRectangle(200,300,300,50);
	iText(210,320,show[5],GLUT_BITMAP_TIMES_ROMAN_24);
}

//easy level
void level(int i)
{
	catno=i;
	iShowBMP(jerry_x,jerry_y,"Menu\\jerry.bmp");
	iShowBMP(0,0,"Menu\\scorecard.bmp");
	
	score_show();
	catshow();
	cheeseshow();
	
	if (phase>=6) trapshow();
	else		  iPauseTimer(3);
	
	gameovercheck();

	if (!eaten) eatcheck();

	if (!gameon)
	{
		iShowBMP(300,300,"Menu\\pause_icon.bmp");
		iShowBMP(608,0,"Menu\\pausemenu.bmp");

		if (menu_x>=644 && menu_x<=742 && menu_y>=64 && menu_y<=88)
			gameon=true;
		else if (menu_x>=644 && menu_x<=742 && menu_y>=37 && menu_y<=60)
		{
			jerry_x=300;	jerry_y=350;
			score=0;		eat=0;
			special=false;	gameon=true;
			cheese_create=false;	cat_create=false;
			trap_create=false;
		}
		else if (menu_x>=644 && menu_x<=742 && menu_y>=8 && menu_y<=32)
		{ 
			gameon=true;
			phase=1;
		}

		menu_x=-1;
		menu_y=-1;
	}
}

//new game menu
void New_game(void)
{
	iShowBMP(0,0,"Menu\\new_game_level.bmp");
	iShowBMP(660,5,"Menu\\level_back_button.bmp");

	jerry_x=300;	jerry_y=350;
	score=0;		eat=0;
	special=false;  gameon=false;
	cheese_create=false;	cat_create=false;

	if (menu_x>=660 && menu_x<=788 && menu_y>=5 && menu_y<=133)
		phase=1;
	else if (menu_x>=480 && menu_x<=600 && menu_y>=540 && menu_y<=590)
	{
		gameon=true;
		phase=5;
	}
	else if (menu_x>=420 && menu_x<=580 && menu_y>=420 && menu_y<=480)
	{
		gameon=true;
		phase=6;
	}
	else if (menu_x>=450 && menu_x<=560 && menu_y>=275 && menu_y<=320)
	{
		gameon=true;
		phase=7;
	}
}

//High score menu.From here the names and the scores of top 5 players are showed.


void High_scores(void)
{	
	if (!read)
	{
		if ( ( from = fopen( "High Score\\highscore.txt" , "r" ) ) == NULL)
		{
			from = fopen( "High Score\\highscore.txt" , "w" );
		
			for (int i=0; i<5; i++)
			{
				strcpy(names[i],"Unknown");
				scores[i]=0;
				fprintf( from, "%s %d\n" , names[i] , scores[i] );
			}

			fclose(from);
		}

		from = fopen( "High Score\\highscore.txt" , "r" );

		i=0;

		while (!feof(from))
		{
			fgets(show[i],79,from);
			i++;
		}

		fclose(from);
		
		read=true;
	}

	iShowBMP(0,0,"Menu\\high_score.bmp");
	
	iSetColor(255,240,245);
	for (int i=0; i<5; i++)	iText(70,430-i*60,show[i],GLUT_BITMAP_TIMES_ROMAN_24);

	//forming the box of back button

	if (!confirm && menu_x>=10 && menu_x<=117 && menu_y>=485 && menu_y<=590) { confirm=false; phase=1; }	//back button
	else if (menu_x>=182 && menu_x<=309 && menu_y>=472 && menu_y<=597)		 confirm=true;

	if (confirm)
	{
		iShowBMP(300,180,"Menu\\popup_window.bmp");

		if (menu_x>=308 && menu_x<=546 && menu_y>=268 && menu_y<=328)
		{
			from=fopen("High Score\\highscore.txt","w");
			
			for (int i=0; i<5; i++)
			{
				strcpy(names[i],"Unknown");
				scores[i]=0;
				fprintf( from, "%s %d\n" , names[i] , scores[i] );
			}

			fclose(from);

			read=confirm=false;
		}
		else if (menu_x>=308 && menu_x<=546 && menu_y>=198 && menu_y<=258)
			confirm=false;
	}
}

//Help menu.From here a player can know the rules of the game.

void Help(void)
{
	//help option

	iShowBMP(0,0,"Menu\\Help.bmp");

	//forming the box of back button

	iShowBMP(25,450,"Menu\\help_back_button.bmp");

	if (menu_x>=25 && menu_x<=143 && menu_y>=450 && menu_y<=578)	phase=1;	//back button
}

//Main menu.From here a player can see the options available such as new game,high score,help and exit

void Menu(void)
{
	//menu graphics

	iShowBMP(0,0,"Menu\\main_menu.bmp");
	gameon=false;

	if		(menu_x>=0 && menu_x<=80 && menu_y>=150 && menu_y<=250)		exit(1);
	else if (menu_x>=680 && menu_x<=800 && menu_y>=310 && menu_y<=380)  phase=2;
	else if (menu_x>=340 && menu_x<=440 && menu_y>=2 && menu_y<=102)	{ read=false; phase=3;}
	else if (menu_x>=190 && menu_x<=300 && menu_y>=5 && menu_y<=85)		phase=4;
}

/* 
	function iDraw() is called again and again by the system.
*/

void iDraw()
{
	//place your drawing codes here	
	iClear();

	if (phase==1)		Menu();
	else if (phase==2)	New_game();
	else if (phase==3)	High_scores();
	else if (phase==4)	Help();
	else if (phase==5)	level(1);
	else if (phase==6)	level(2);
	else if (phase==7)	level(2);
	else if (phase==8)	game_over();
	else if (phase==9)	highscoreset();
}



/* 
	function iMouseMove() is called when the user presses and drags the mouse.
	(mx, my) is the position where the mouse pointer is.
*/

void iMouseMove(int mx, int my)
{
	//place your codes here
}



/* 
	function iMouse() is called when the user presses/releases the mouse.
	(mx, my) is the position where the mouse pointer is.
*/

void iMouse(int button, int state, int mx, int my)
{
	if(button == GLUT_LEFT_BUTTON && state == GLUT_DOWN)
	{
		
		//place your codes here
		menu_x=mx;	menu_y=my;
		
	}
	if(button == GLUT_RIGHT_BUTTON && state == GLUT_DOWN)
	{
		//place your codes here	
	}
}



/*
	function iKeyboard() is called whenever the user hits a key in keyboard.
	key- holds the ASCII value of the key pressed. 
*/

void iKeyboard(unsigned char key)
{
	
	//place your codes for other keys here

	if (key=='p') gameon=false;
	else if (key=='r') gameon=true;

	if (phase==9)
	{
		if ( (key>='A' && key<='Z') || (key>='a' && key<='z') || (key>='0' && key<='9'))
		{
			show[5][typed++]=key;
			show[5][typed]='\0';
		}
		else if (key==8)
			show[5][--typed]='\0';
		else if ( key=='\r')
		{
			strcpy(names[indx],show[5]);

			from = fopen( "High Score\\highscore.txt" , "w" );
		
			for (int i=0; i<5; i++)
				fprintf( from, "%s %d\n" , names[i] , scores[i] );

			fclose(from);
			read=false;
			phase=3;
		}
	}
}

/*
	function iSpecialKeyboard() is called whenver user hits special keys like-
	function keys, home, end, pg up, pg down, arraows etc. you have to use 
	appropriate constants to detect them. A list is:
	GLUT_KEY_F1, GLUT_KEY_F2, GLUT_KEY_F3, GLUT_KEY_F4, GLUT_KEY_F5, GLUT_KEY_F6, 
	GLUT_KEY_F7, GLUT_KEY_F8, GLUT_KEY_F9, GLUT_KEY_F10, GLUT_KEY_F11, GLUT_KEY_F12, 
	GLUT_KEY_LEFT, GLUT_KEY_UP, GLUT_KEY_RIGHT, GLUT_KEY_DOWN, GLUT_KEY_PAGE UP, 
	GLUT_KEY_PAGE DOWN, GLUT_KEY_HOME, GLUT_KEY_END, GLUT_KEY_INSERT 
*/


void iSpecialKeyboard(unsigned char key)
{

	if(key == GLUT_KEY_END)
	{
		exit(0);	
	}

	if (gameon)
	{
		if(key == GLUT_KEY_UP && jerry_y<=568-jd)			jerry_y+=jd;
		else if(key == GLUT_KEY_DOWN && jerry_y>=jd+100)	jerry_y-=jd;
		else if(key == GLUT_KEY_LEFT && jerry_x>=jd)		jerry_x-=jd;
		else if(key == GLUT_KEY_RIGHT && jerry_x<=768-jd)	jerry_x+=jd;
	}

	//place your codes for other keys here
}



int main()
{
	//place your own initialization codes here.

	phase=1;
	srand(time(NULL));
	iSetTimer(10,changing);
	iSetTimer(1000,timerreducer);
	iSetTimer(100,timerlength);
	iSetTimer(1000,traptimer);
	
	iInitialize(800,600,"Cheese run");

	return 0;
}