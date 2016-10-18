using System.Collections.Generic;

namespace GuitarChordFinder {

	/// <summary>
	/// Represents a chord.
	/// </summary>
	public class Chord
	{
		HashSet<Note> notes;
		public HashSet<Note> Notes
		{
			get { return notes; }
			set { notes = value; }
		}


		bool rootOmissionAllowed = false;
		Note root, bass;
		int third, fifth, seventh, ninth, eleventh, thirteenth;
		public Note Root
		{
			get { return root; }
			set { root = value; }
		}
		public int Third
		{
			get { return third; }
			set { third = value; }
		}
		public int Fifth
		{
			get { return fifth; }
			set { fifth = value; }
		}
		public int Seventh
		{
			get { return seventh; }
			set { seventh = value; }
		}
		public int Ninth
		{
			get { return ninth; }
			set { ninth = value; }
		}
		public int Eleventh
		{
			get { return eleventh; }
			set { eleventh = value; }
		}
		public int Thirteenth
		{
			get { return thirteenth; }
			set { thirteenth = value; }
		}
		public Note Bass
		{
			get { return bass; }
			set { bass = value; }
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="notes">List of Notes present in the chord.</param>
		/// <param name="root">Root note.</param>
		/// <param name="third">Quality of third.</param>
		/// <param name="fifth">Quality of fifth.</param>
		/// <param name="seventh">Quality of seventh.</param>
		/// <param name="ninth">Quality of ninth.</param>
		/// <param name="eleventh">Quality of eleventh.</param>
		/// <param name="thirteenth">Quality of thirteenth.</param>
		/// <param name="bass">Bass note.</param>
		/// <param name="rootOmissionAllowed">True if it is allowed to omit the root in the fingering.</param>
		public Chord(HashSet<Note> notes, Note root, int third, int fifth, int seventh, int ninth, int eleventh, int thirteenth, Note bass, bool rootOmissionAllowed)
		{
			this.root = root;
			this.third = third;
			this.fifth = fifth;
			this.seventh = seventh;
			this.ninth = ninth;
			this.eleventh = eleventh;
			this.thirteenth = thirteenth;
			this.notes = notes;
			this.bass = bass;
			this.rootOmissionAllowed = rootOmissionAllowed;
		}

		public bool isRootOmissionAllowed()
		{
			return rootOmissionAllowed;
		}
	}


	/// <summary>
	/// Describes the chord skeleton (no absolute pitches, only relative stepwise distances)
	/// </summary>
	class ChordFormula
	{
		private string name;
		public string Name { get { return name; } }

		private int third, fifth, seventh, ninth, eleventh, thirteenth;

		public int Third
		{
			get { return third; }
			set { third = value; }
		}
		public int Fifth
		{
			get { return fifth; }
			set { fifth = value; }
		}
		public int Seventh
		{
			get { return seventh; }
			set { seventh = value; }
		}
		public int Ninth
		{
			get { return ninth; }
			set { ninth = value; }
		}
		public int Eleventh
		{
			get { return eleventh; }
			set { eleventh = value; }
		}
		public int Thirteenth
		{
			get { return thirteenth; }
			set { thirteenth = value; }
		}


		public ChordFormula(string name, int third, int fifth, int seventh, int ninth, int eleventh, int thirteenth)
		{
			this.name = name;
			this.third = third;
			this.fifth = fifth;
			this.seventh = seventh;
			this.ninth = ninth;
			this.eleventh = eleventh;
			this.thirteenth = thirteenth;
		}
	}

}
