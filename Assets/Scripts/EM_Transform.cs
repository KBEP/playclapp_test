using UnityEngine;

public static class EM_Transform
{
	public static Transform Find (this Transform t, string path, bool log)
	{
		Transform result = t.Find(path);
		if (result == null && log) Debug.LogError(string.Format("Transform '{0}' not found.", path));
		return result;
	}

	public static T GetChildComponent<T> (this Transform t, string path, bool log = true) where T : Component
	{
		Transform child = t.Find(path);

		if (child == null)
		{
			if (log)
			{
				string fullPath = TransformPathGenerator.GenFullPath(child, path);
				Debug.LogError(string.Format("Transform '{0}' not found.", fullPath));
			}
			return null;
		}

		if (!child.TryGetComponent<T>(out T component))
		{
			if (log)
			{
				string fullPath = TransformPathGenerator.GenFullPath(child, path);
				Debug.LogError(string.Format("Component '{0}' not found in '{1}'.", typeof(T).FullName, fullPath));
			}
			return null;
		}

		return component;
	}

	public static class TransformPathGenerator
	{
		static readonly System.Text.StringBuilder builder = new System.Text.StringBuilder();
		
		public static string GenFullPath (Transform transform, string addPath)
		{
			builder.Clear();

			while (transform != null)
			{
				builder.Insert(0, transform.name);
				builder.Insert(0, '/');
				transform = transform.parent;
			}

			if (addPath != null)
			{
				if (!addPath.StartsWith('/')) builder.Append('/');
				builder.Append(addPath);
			}

			string result = builder.ToString();

			builder.Clear();

			return result;
		}
	}
}
