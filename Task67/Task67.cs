namespace Task67
{
	// 67. Given a singly linked list, find the middle of the list.
	// Time: O(n)
	// Space: O(1)
	public static class Task67
	{
        // 1 -> 1
		// 1 2 -> 2
		// 1 2 3 -> 2
		// 1 2 3 4 -> 3
		// 1 2 3 4 5 -> 3 
		public static Node FindMiddle (Node list)
		{
			if (list?.Next == null)
				return list;

			var node1 = list;
			var node2 = list.Next;
			while (true)
            {
				node1 = node1.Next;
				node2 = node2?.Next?.Next;
                if (node2 == null) return node1;
			}
		}
	}
}