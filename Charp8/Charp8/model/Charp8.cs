using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charp8.model {
    public class Charp8 {
        #region CPU Specifications
        /*
            - The Chip 8 has 35 opcodes which are all two bytes long. To store the current 
            opcode, we need a data type that allows us to store two bytes. An unsigned short 
            has the length of two bytes and therefor fits our needs:
         */
        private ushort opcode;

        /*
            - The Chip 8 has 4K memory in total, which we can emulated as:
         */
        private byte[] memory;//[4096]

        /*
            - CPU registers: The Chip 8 has 15 8-bit general purpose registers named V0,V1 up 
            to VE. The 16th register is used  for the ‘carry flag’. Eight bits is one byte 
            so we can use an unsigned char for this purpose:
         */
        private byte[] V;//[16]

        /*
            - There is an Index register I and a program counter (pc) which can have a value 
            from 0x000 to 0xFFF
         */
        private ushort I;
        private ushort pc;

        /*
            - 0x000-0x1FF - Chip 8 interpreter (contains font set in emu)
            - 0x050-0x0A0 - Used for the built in 4x5 pixel font set (0-F)
            - 0x200-0xFFF - Program ROM and work RAM
         */

        /*
            - The graphics system: The chip 8 has one instruction that draws sprite to the 
            screen. Drawing is done in XOR mode and if a pixel is turned off as a result of 
            drawing, the VF register is set. This is used for collision detection.
            - The graphics of the Chip 8 are black and white and the screen has a total of 
            2048 pixels (64 x 32). This can easily be implemented using an array that hold 
            the pixel state (1 or 0):
         */
        private byte[] gfx = new byte[64 * 32];

        /*
            - Interupts and hardware registers. The Chip 8 has none, but there are two timer 
            registers that count at 60 Hz. When set above zero they will count down to zero.
            - The system’s buzzer sounds whenever the sound timer reaches zero.
         */
        private byte delay_timer;
        private byte sound_timer;

        /*
            - It is important to know that the Chip 8 instruction set has opcodes that allow the 
            program to jump to a certain address or call a subroutine. While the specification 
            don’t mention a stack, you will need to implement one as part of the interpreter 
            yourself. The stack is used to remember the current location before a jump is 
            performed. So anytime you perform a jump or call a subroutine, store the program 
            counter in the stack before proceeding. The system has 16 levels of stack and in 
            order to remember which level of the stack is used, you need to implement a stack 
            pointer (sp).
         */
        private ushort[] stack = new ushort[16];
        private ushort sp;

        /*
            - Finally, the Chip 8 has a HEX based keypad (0x0-0xF), you can use an array to store 
            the current state of the key.
         */
        private byte[] key = new byte[16];

        private bool drawFlag;

        /*
            - This is the Chip 8 font set. Each number or character is 4 pixels wide and 5 pixel 
            high.
         */
        private byte[] chip8_fontset =
        {
            0xF0, 0x90, 0x90, 0x90, 0xF0, // 0
            0x20, 0x60, 0x20, 0x20, 0x70, // 1
            0xF0, 0x10, 0xF0, 0x80, 0xF0, // 2
            0xF0, 0x10, 0xF0, 0x10, 0xF0, // 3
            0x90, 0x90, 0xF0, 0x10, 0x10, // 4
            0xF0, 0x80, 0xF0, 0x10, 0xF0, // 5
            0xF0, 0x80, 0xF0, 0x90, 0xF0, // 6
            0xF0, 0x10, 0x20, 0x40, 0x40, // 7
            0xF0, 0x90, 0xF0, 0x90, 0xF0, // 8
            0xF0, 0x90, 0xF0, 0x10, 0xF0, // 9
            0xF0, 0x90, 0xF0, 0x90, 0x90, // A
            0xE0, 0x90, 0xE0, 0x90, 0xE0, // B
            0xF0, 0x80, 0x80, 0x80, 0xF0, // C
            0xE0, 0x90, 0x90, 0x90, 0xE0, // D
            0xF0, 0x80, 0xF0, 0x80, 0xF0, // E
            0xF0, 0x80, 0xF0, 0x80, 0x80  // F
        };
        #endregion

        #region Initialize system
        public void initialize() {
            // Initialize registers and memory once
            pc      = 0x200;    // Program counter starts at 0x200 [512]
            opcode  = 0;        // Reset current opcode
            I       = 0;        // Reset index register
            sp      = 0;        // Reset stack pointer

            // Clear display	
            // Clear stack
            // Clear registers V0-VF
            // Clear memory

            // Load fontset
            for (int i = 0; i < 80; ++i) {
                memory[i] = chip8_fontset[i];
            }

            // Reset timers
        }
        #endregion

        #region Loading the program into the memory
        public bool loadGame(byte[] buffer) {
            int bufferSize = buffer.Length;

            /*
                - After you have initialized the emulator, load the program into the memory 
                (use fopen in binary mode) and start filling the memory at location: 
                0x200 == 512.
             */
            for (int i = 0; i < bufferSize; ++i) {
                memory[i + 512] = buffer[i];
            }

            return true;
        }

        public bool loadGame(string fileName) {
            // If the file doesn't exist, exit the application
            if (!File.Exists(fileName)) {
                Console.Write("File {0} doesn't exist!", fileName);
                return false;
            }

            // Open the file in binary mode
            using (BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open))) {
                // Loading the game into memory
                /*
                    - After you have initialized the emulator, load the program into the memory 
                    (use fopen in binary mode) and start filling the memory at location: 
                    0x200 == 512.
                 */
                for (int i = 0; i < br.BaseStream.Length; i++) {
                    memory[i + 512] = br.ReadByte();
                }
            }

            return true;
        }
        #endregion

        #region Start the emulation
        public void emulateCycle() {
            // Fetch Opcode
            // Decode Opcode
            // Execute Opcode

            // Update timers
        }
        #endregion

        public void setKeys() {

        }
    }
}
