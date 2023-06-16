# BubbleLeaks-2D

## Movimiento de Mario
Mario debe poder moverse a izquierda y derecha controlado por las flechas izquierda y derecha. La velocidad de movimiento sera 3.2f. Mario se parara instantaneamente en el momento en que se suelte la tecla que lo mantiene en movimiento. Ademas, Mario puede cambiar el sentido de su movimiento horizontal o frenarse independientemente de si esta en el suelo o en el aire.
Mientras Mario esta parado se ejecutara la animacion Idle, y cuando este en movimiento sin saltar la animacion Walking. En este ultimo caso se debera orientar la animacion en el sentido del movimiento y cuando Mario se pare quedará con la orientacion que tenia mientras se movia.
Mario podra saltar impulsandose hacia arriba con una fuerza de 6.5f aplicada a su Rigidbody2D en forma de impulso.Este salto solo podra efectuarlo cuando este en el suelo, pero tambien puede darse de nuevo impulso estando en el aire, una sola vez por salto, con una fuerza de 4f.
Mientras salte, Mario deberá ejecutar la animacion Jumping.
Las animaciones de Mario y el Animator que permite gestionarlas y cambiar de una a otra ya estan creadas y se suministran en el proyecto. Para realizar el ejercicio se deberan controlar las transiciones entre estados del Animator usando sus parametros de tipo bool walking y jumping.
Mario incluye un script Mario.cs que contiene una funcion IsGrounded() que testea si Mario esta en el suelo mediante un Raycast.Esta funcion sigue detectando que Mario esta en el suelo en los primeros frames de un salto.
