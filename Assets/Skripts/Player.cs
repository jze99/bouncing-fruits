using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb_Player;//физический элемент нашего игрока 
    [SerializeField]
    float jump_Power;//сила с которой прыгает игрок
    [SerializeField]
    private GameObject[] platforms;//список существующих платформ которые можно создать 
    [SerializeField]
    private List<GameObject> used_Platforms = new List<GameObject>();//список используемых платформ
    [SerializeField]
    private GameObject old_Platform;//старая платформа для определения координат новой
    public Camera camera_Main;
    private bool left=false;//возможность перемещаться в лево
    private bool right=false;//возможность перемещаться в право
    [SerializeField]
    private float speed;//скорость перемещения по горизонтали
    private int rand;//рандомный сектор на экране
    private Save_Load save_Load;//класс для сохранения изагрузки данных
    private int score;
    private string name_Platform;
    [SerializeField]
    private Data_base data_Base;
    public Sprite skin;

    private void Start()
    {
        rb_Player=gameObject.GetComponent<Rigidbody2D>();//находим у игроака физический элемент
        save_Load=gameObject.GetComponent<Save_Load>();//находим компонент сохранения и загрузки
        save_Load.Load_Record_Score();
    }
    private void OnCollisionEnter2D(Collision2D other)//эвент когда наш игрок с чемнибть сталкивается 
    {
        name_Platform = other.transform.tag;
        if(name_Platform=="red"||name_Platform=="gren"||name_Platform=="blu")//спрашиваем столкнулся ли он с платформой
        {
            rb_Player.AddForce(transform.up*jump_Power);//даём ускорение для прыжка 
            if(other.gameObject.GetComponent<Platform>().activ==false)
            {
                Instante_Platform();//создаём платформу
                other.gameObject.GetComponent<Platform>().Activiti_Platform();//меняем индикатор активности платформы
                save_Load.Save_Record_Score(score++);//передаём счёт в другой метод для сохранения и вывода на экран
                switch (name_Platform)//спрашиваем на какой конкретно платформе мы находимся
                {
                    case "red":
                        data_Base.platform_Red++;
                        break;
                    case "gren":
                        data_Base.platform_Gren++;
                        break;
                    case "blu":
                        data_Base.platform_Blu++;
                        break;
                }
            }
        }
    }
    public void Button_Left_On()//если мы зажали левую часть экрана 
    {
        left=true;
    }
    public void Button_Left_Off()//если мы отпустили левую часть экрана 
    {
        left=false;
    }
    public void Button_Right_On()//если мы зажали правую часть экрана 
    {
        right=true;
    }
     public void Button_Right_Off()//если мы отпустили правую часть экрана 
    {
        right=false;
    }
    private int Moving()//метод для перемещения нашего игрока 
    {
        if(left==true)//спрашиваем зажали ли мы левую часть экрана 
        {
            transform.position -= new Vector3(speed,0,0);//уменьшаем координаты нашего игрока для перемещения 
            if(transform.position.x<=-3)//спрашиваем не начал ли наш игров вываливатся за экран 
            {
                transform.position = new Vector2(3,transform.position.y);//перемешаем нашего игрока в противоположную часть экрана 
            }
        }
        else if (right==true)//если мы зажали правую часть экрана 
        {
            transform.position += new Vector3(speed,0,0);//увеличиваем координаты нашего игрока для перемещения
            if(transform.position.x>=3)//спрашиваем не вывалился ли он за экран с право
            {
                transform.position = new Vector2(-3,transform.position.y);//перемещаем игрока в противоложную часть экрана 
            }
        }
        return 0;//возвращаем 0
    }
    private void Instante_Platform()
    {
        Platform_Position();
        old_Platform=Instantiate(platforms[Random_Platform(rand)],new Vector3(Platform_Position(rand),old_Platform.transform.position.y+1.5f),Quaternion.identity);//создаём и назначаем старую плтформу как новую
        used_Platforms.Add(old_Platform);//добавляем новую платформу в масив для контроля количества платформ
    }
    private float Platform_Position()//метод для обозначения позиции платформы 
    {
        rand = Random.Range(0,5);//находим рандомное место 
        switch(rand)
        {
            case 0:
                if(old_Platform.transform.position.x!=-2.5)
                    return rand;
                else
                {
                    rand++;
                    return rand;
                }
            case 1:
                if(old_Platform.transform.position.x!=-1.5)
                    return rand;
                else
                {
                    int i = Random.Range(0,1);
                    if(i==0)
                        rand--;
                    else if(i==1)
                        rand++;
                    return rand;    
                }
            case 2:
                if(old_Platform.transform.position.x!=-0.5)
                    return rand;
                else
                {
                    int i = Random.Range(0,1);
                    if(i==0) 
                        rand--;
                    else if(i==1)
                        rand++;
                    return rand;    
                }
            case 3:
                if(old_Platform.transform.position.x!=0.5)
                    return rand;
                else
                {
                    int i = Random.Range(0,1);
                    if(i==0)  
                        rand--;
                    else if(i==1)
                        rand++;
                    return rand;    
                }
            case 4:
                if(old_Platform.transform.position.x!=1.5)
                    return rand;
                else
                {
                    int i = Random.Range(0,1);
                    if(i==0)   
                        rand--;
                    else if(i==1)
                        rand++;
                    return rand;    
                }
            case 5:
                if(old_Platform.transform.position.x!=2.5)
                    return rand;
                else
                {
                    rand--;
                    return rand;
                }
        }
        return 0;
    }
    private float Platform_Position(int _rand)//преабразовывает рандомноый сектар на экране в координаты
    {
        switch(_rand)
        {
            case 0:
                return -2.5f;
            case 1:
                return -1.5f;
            case 2:
                return -0.5f;
            case 3: 
                return 0.5f;
            case 4:
                return 1.5f;
            case 5:
                return 2.5f;
        }
        return 0;
    }
    private int Random_Platform(int _rand)//выберает рандомную платформу из списка
    {
        if(_rand==0||_rand==5)
        {
            return 0;
        }
        else
            return Random.Range(0,platforms.Length);
    }
    private void Camera_Muving()//метод который заставляет нашу камеру плавно тащится за игроком
    {
        if(camera_Main.transform.position.y<transform.position.y)
        {
            camera_Main.transform.position +=new Vector3(0,1.5f*Time.deltaTime,0);
        }
    }
    private void Velosity()
    {
        if(rb_Player.velocity.y>=6)
            rb_Player.velocity=new Vector2(0,5);
    }
    private void Platform_Controler()//контролирует количество платформ на сцене
    {
         if(used_Platforms.Count>5)
        {
            Destroy(used_Platforms[0]);
            used_Platforms.RemoveAt(0);
            used_Platforms.RemoveAll (x => x == null);
        } 
    }
    private void FixedUpdate()//фиксированое обновление 
    {
        Moving();//вызываем мметод для перемещения
        Camera_Muving();//двигаем камеру за игроком
        Velosity();//ограничиваем силу прыжка
        Platform_Controler();//контролирует количество платформ на сцене
    }
    private void LateUpdate()
    {

    }
}
