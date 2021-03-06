﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameOneButtonGame
{
    public partial class PlayerController : Microsoft.Xna.Framework.GameComponent
    {
        Character character;

        public PlayerController(Game game) :
            base(game)
        {
            character = new Character(game);
        }

        public void HandleKeyboardInput(float time)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                character.velocity = 0;
                character.acceleration = .01f;
                character.acceleration += .5f;

                character.velocity += character.acceleration * character.acceleration * (time / 1000);
                character.position += (character.direction * character.speed) * (time / 1000);
            }
        }

        public Texture2D GetPlatformTexture()
        {
            return character.GetPlatformTexture();
        }

        public Texture2D GetCharacterTexture()
        {
            return character.GetCharacterTexture();
        }

        public Texture2D GetFlagTexture()
        {
            return character.GetFlagTexture();
        }

        public Texture2D GetBoulderTexture()
        {
            return character.GetBoulderTexture();
        }

        public void SetSpriteTextures(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            character.SetSpriteTextures(content);
        }

        public Vector2 GetPosition()
        {
            return character.position;
        }

        public Vector2 GetStartPosition()
        {
            return character.startPosition;
        }

        public void SetPosition(Vector2 position)
        {
            character.position = position;
        }

        public SpriteEffects GetSpriteEffects()
        {
            return character.GetSpriteEffects();
        }

        public Rectangle GetPlayerBounds()
        {
            return character.characterBoundingBox;
        }

        public void UpdateRectangleCharacter()
        {
            character.characterBoundingBox.X = (int)character.position.X;
            character.characterBoundingBox.Y = (int)character.position.Y;
        }

        public bool CheckBoulderCollision(Boulder[] boulderArray)
        {
            for (int i = 0; i < boulderArray.Length; i++)
            {
                if (GetPlayerBounds().Intersects(boulderArray[i].boulderBoundingBox))
                {
                    ResetCharacterPosition();
                    return true;
                }
            }
            return false;
        }

        public bool CheckFlagCollision()
        {
            if (GetPlayerBounds().Intersects(character.GetFlagBoundryBox()))
            {
                ResetCharacterPosition();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ResetCharacterPosition()
        {
            character.position = character.startPosition;
        }

    }
}
