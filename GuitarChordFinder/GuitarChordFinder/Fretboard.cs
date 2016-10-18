using System.Collections.Generic;

namespace GuitarChordFinder {
	/// <summary>
	/// Class representing the guitar fretboard. 
	/// </summary>
	class Fretboard
	{
		int maxFret;
		int stringsCount;
		Note[] tuning;

		public int StringsCount
		{
			get { return stringsCount; }
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="maxFret">The highest (usable) fret on the fretboard.</param>
		/// <param name="stringsCount">Number of strings.</param>
		/// <param name="tuning"></param>
		public Fretboard(int maxFret, int stringsCount, Note[] tuning)
		{
			this.maxFret = maxFret;
			this.stringsCount = stringsCount;
			this.tuning = tuning;
		}

		public Note GetTuning(int index)
		{
			return tuning[index];
		}
		public void SetTuning(int index, Note value)
		{
			tuning[index] = value;
		}

		/// <summary>
		/// Returns a ragged list of all the locations of given notes on individual strings.
		/// </summary>
		/// <param name="notes">Notes to be searched for.</param>
		/// <returns></returns>
		public List<List<int>> findNotesOnFretboard(HashSet<Note> notes)
		{
			List<List<int>> notesOnFretboard = new List<List<int>>();

			for (int str = 0; str < StringsCount; str++)
			{
				notesOnFretboard.Add(new List<int>());
				for (int fret = 0; fret < maxFret; fret++)
				{
					Note currentNote = (Note)(((int)tuning[str] + fret) % 12);
					if (notes.Contains(currentNote))
					{
						notesOnFretboard[str].Add(fret);
					}
				}
			}

			// first two strings can be muted explicitly (others only if there is no other feasible solution (handled elsewhere))
			notesOnFretboard[0].Add(-1);
			notesOnFretboard[1].Add(-1);

			return notesOnFretboard;
		}
	}

}
