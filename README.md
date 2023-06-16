# BubbleLeaks-2D

## Movimiento de Mario
Mario debe poder moverse a izquierda y derecha controlado por las flechas izquierda y derecha. La velocidad de movimiento sera 3.2f. Mario se parara instantaneamente en el momento en que se suelte la tecla que lo mantiene en movimiento. Ademas, Mario puede cambiar el sentido de su movimiento horizontal o frenarse independientemente de si esta en el suelo o en el aire.

Mientras Mario esta parado se ejecutara la animacion Idle, y cuando este en movimiento sin saltar la animacion Walking. En este ultimo caso se debera orientar la animacion en el sentido del movimiento y cuando Mario se pare quedará con la orientacion que tenia mientras se movia.

Mario podra saltar impulsandose hacia arriba con una fuerza de 6.5f aplicada a su Rigidbody2D en forma de impulso.Este salto solo podra efectuarlo cuando este en el suelo, pero tambien puede darse de nuevo impulso estando en el aire, una sola vez por salto, con una fuerza de 4f.

Mientras salte, Mario deberá ejecutar la animacion Jumping.

Las animaciones de Mario y el Animator que permite gestionarlas y cambiar de una a otra ya estan creadas y se suministran en el proyecto. Para realizar el ejercicio se deberan controlar las transiciones entre estados del Animator usando sus parametros de tipo bool walking y jumping.
Mario incluye un script Mario.cs que contiene una funcion IsGrounded() que testea si Mario esta en el suelo mediante un Raycast.Esta funcion sigue detectando que Mario esta en el suelo en los primeros frames de un salto.

## Espaneo de burbujas
Debera crearse un prefab para las burbujas, Bubble.
Deberá crearse un GameManager que se encargara, entre otras cosas de espanear burbujas.

El espaneo se realizara desde una corrutina que cada 0.1f segundos se dicidira espanear una burbuja con una probabilidad del 4%. En caso de decidir espanear una burbuja, el punto de espaneo se elegira al azar en un rectangulo entre las coordenadas horizontales -4f y 4f y entre las coordenadas verticales -1f y 3f.

## Comportamiento de las burbujas 
Las burbujas una vez espaneadas comenzaran a crecer, mostrando una animacion creada a partir del tilesheet bubble. Mientras continue este proceso de crecimiento la burbuja permanecera fija en el lugar donde fue espaneada.Una vez acabada la animacion de espaneo, la burbuja escogera una direccion de movimiento al azar y comenzara a moverse en esa direccion a la velocidad de 0.8f.

Mediante una corrutina la burbuja cambiara su velocidad aleatoriamente cada 0.5s. Para cambiar la velocidad se sumara a la velocidad actual de la burbuja un vector aleatorio con un componente horizontal en el rango -0.1f a 0.1f y un componente vertical en el rango -0.2f a 0.1f.Esta asimetria en el componente vertical debe causar que la burbuja tienda a caer con algo mas de probabilidad que a subir.

## Destruccion de las burbujas
Las burbujas no deben colisionar entre si.

Las burbujas deben detectar el choque con Mario, lo que provocara el inicio de su destruccion y la anotacion de 10 puntos en el GameManager.La anotacion se hara en el momento de la colision con el personaje.El GameManager mostrara por consola el nuevo total de puntos acumulado y reproducira el sonido bubbleDestroyedAudio.mp3.

Tambien se destruira la burbuja si colisiona con cualquiera de los colisionadores que delimitan la pantalla.En este caso, el GameManager actualizara el valor Health mostrara el nuevo valor por consola y reproducira el sonido bubbleCollisionAudio.mp3. El valor de Health comenzara en 10 y se restara 1 por cada choque de una burbuja con los limites de la pantalla. Si la cuenta llega a cero se establecera la condicion de GameOver.

En el momento de inicio de la destruccion de una burbuja, tanto en el caso que sea Mario quien la destruya como que se destruya por colisionar con los limites de la escena, la burbuja debera detener su movimiento e iniciar la animacion de destruccion, destruyendose el objeto al acabar esta animacion. Ademas debera evitar que se sigan pudiendo detectar colisiones, evitando asi situaciones como que una burbuja que se esta destruyendo por haber chocado con un muro choque todavia con Mario y se anoten los correspondientes puntos. Esto se puede evitar desactivando el colisionador de la burbuja o con un mecanismo de capas.

La animacion de destruccion de la burbuja debe crearse a partir del tilesheet bubble-destroy.

## Fin del juego

Al establecerse la condicion de GameOver, tanto las burbujas como Mario dejaran de moverse, y en el caso de Mario, de responder a las ordenes del jugador.No es necesario hacer que Mario deje de caer en caso de que este en el aire cuando llega el GameOver. Tambien se detendra el espaneo de nuevas burbujas.
