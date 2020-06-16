using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class SaveLoadMenu : MonoBehaviour {

	public Text menuLabel, actionButtonLabel;

	public InputField nameInput;

	public RectTransform listContent;

	public SaveLoadItem itemPrefab;

	bool saveMode;

    public void Open (bool saveMode) {
		this.saveMode = saveMode;
		if (saveMode) {
			menuLabel.text = "Зберегти схему";
			actionButtonLabel.text = "Зберегти";
		}
		else {
			menuLabel.text = "Завантажити схему";
			actionButtonLabel.text = "Завантажити";
		}
		FillList();
		gameObject.SetActive(true);
	}

	public void Close () {
		gameObject.SetActive(false);
	}

	public void Action () {
		string path = GetSelectedPath();
		if (path == null) {
			return;
		}
		if (saveMode) {
			Save(path);
		}
		else {
			Load(path);
		}
		Close();
	}

	public void SelectItem (string name) {
		nameInput.text = name;
	}

	public void Delete () {
		string path = GetSelectedPath();
		if (path == null) {
			return;
		}
		if (File.Exists(path)) {
			File.Delete(path);
		}
		nameInput.text = "";
		FillList();
	}

	void FillList () {
		for (int i = 0; i < listContent.childCount; i++) {
			Destroy(listContent.GetChild(i).gameObject);
		}
		string[] paths =
			Directory.GetFiles(Application.persistentDataPath, "*.sbc");
		Array.Sort(paths);
		for (int i = 0; i < paths.Length; i++) {
			SaveLoadItem item = Instantiate(itemPrefab);
			item.menu = this;
			item.MapName = Path.GetFileNameWithoutExtension(paths[i]);
			item.transform.SetParent(listContent, false);
		}
	}

	string GetSelectedPath () {
		string mapName = nameInput.text;
		if (mapName.Length == 0) {
			return null;
		}
		return Path.Combine(Application.persistentDataPath, mapName + ".sbc");
	}

	void Save (string path) {
		using (
			BinaryWriter writer =
			new BinaryWriter(File.Open(path, FileMode.Create))
		) {
			writer.Write(DataClass.version);
			DataClass.objectManager.Save(writer);
		}
	}

	void Load (string path) {
		if (!File.Exists(path)) {
			Debug.LogError("File does not exist " + path);
			return;
		}
		using (BinaryReader reader = new BinaryReader(File.OpenRead(path))) {
			int version = reader.ReadInt32();
			if (version == DataClass.version)
			{
				DataClass.objectManager.Load(reader);
			}
			else {
				Debug.LogWarning("Unknown map format " + version);
			}
		}
	}
}