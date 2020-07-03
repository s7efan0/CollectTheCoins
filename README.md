# Collect the coins

Проектната задача е едноставна видео игра во која имаме карактер со кој се движиме низ левелот(формата). 
Во левелот мораме да собираме парички, а излегуваме од него кога ќе ги собереме сите парички. 
Постојат препреки кои го враќаат играчот на почеток па затоа треба да се избегнуваат.

На стартување на играта ќе ни се појави формата за главното мени. Посотјат неколку опции 
можеме да зачуваме или да продолжиме од некој претходно зачуван фајл. При зачувување на прогресот
се зачувува листа од броеви, а при продолжување ја изминуваме листата и ги овозможуваме мапираните копчиња. Стартување на нова игра не враќа на почеток, односно ја празни листата и ги оневозможува копчињата, постои и копче за крај. Копчето за левел 1 е оневозможени потребно е да се успешно помине туторијалот кој служи за за покажување на можностите за играње.

![](./images/MainMenu.png)

Највпечатливо и најинтересно овде се анимациите на играчот кој може да се наоѓа во состојба на паѓање, скокање, трчање и мирување. Ваквата функционалност е постигната со шаблонот за развој на софтвер наречен State pattern.

![](./images/playerAnimations.gif)

Имплементацијата на шаблонот е следна, потрени ни се транцизиите од состојбите кој ги мапираме во функции. Затоа правиме интерфејс.

```C#
    interface IAnimator
    {
        void animate();

        void reload();

        void startRunning();

        void idle();

        void jumpUp();

        void jumpDown();

        void lookLeft();

        void lookRight();
    }
```
Во класата Player имаме промелива за моменталната анимација(состојба). Чија метода animate() се повикува од тајмер tAnimator.

```c#
    IAnimator currentAnimation
```

Исто така во класата имаме истанци од сите можни состојби. Кои го имаат имплементирано интерфејсот IAnimator и имаат промлеива Player player која покажува до играчот и во 
зависност од повиканата функција може да ја промени моменталната состојба.

```c#
    AnimationIdleRight animationIdleRight;
    AnimationRunRight animationRunRight;
    AnimationJumpDownRight animationJumpDownRight;
    AnimationJumpUpRight animationJumpUpRight;
    AnimationIdleLeft animationIdleLeft;
    AnimationRunLeft animationRunLeft;
    AnimationJumpDownLeft animationJumpDownLeft;
    AnimationJumpUpLeft animationJumpUpLeft;
```

Пример ако currentAnimation е еднаква на AnimationRunRight и ја повикаме функцијата currentAnimation.idle() (таа логика се справува во функцијата animationStateChange()) тогаш ќе ја променима моменатлната состојба во мирување AnimationIdleRight.

```c#
        public virtual void idle()
        {
            player.currentAnimation = player.animationIdleRight;
        }
```
Посложените анимации како AnimationRunRight содржат поврзана листа од слики кои ја менуваат моменталнта слика на PictureBox на играчит во следната на повикување на animate() методата. 

```c#
    LinkedList<Image> listsOfImages
```

Кога стасаме на последната ја менуваме во првата. 

```c#
        public void animate()
        {
            player.pictureBox.Image = currentImage.Value;            
            currentImage = currentImage.Next;
        }
```

Со тоа го добиваме ефектот на движење. Кога ќе ги собереме паричките го заминуваме левелот и го одклучуваме следниот. Оденсувањето на паричките е задача на CoinManager, класата го менаџира нивниот број, видливост(дали се собрани) и анимација(нема State patern бидејќи е една состојба). Постојат и препреки кои можат да бидат стационарни и подвижни при судрање со нив играчит се враќа на почеток.

![](./images/avoidObstacles.gif)
