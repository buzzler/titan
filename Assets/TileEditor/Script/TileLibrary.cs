using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("Config")]
public	class TileConfig {
	private	static TileConfig _instance;
	public	static TileConfig Instance	{ get { return _instance; } }

	[XmlElement("Library")]
	public	TileLibrary	library;

	public	static void LoadFromText(string text) {
		var serializer = new XmlSerializer(typeof(TileConfig));
		_instance = serializer.Deserialize(new StringReader(text)) as TileConfig;
		_instance.library.Hashing();
	}
}

public class TileLibrary {
	[XmlElement("Category")]
	public	TileCategory[]						categories;
	private	Dictionary<string, TileCategory>	_dictionary;

	public	TileLibrary() {
		categories = new TileCategory[0];
		_dictionary = new Dictionary<string, TileCategory>();
	}

	public	void Hashing() {
		_dictionary.Clear();
		for (int i = categories.Length-1 ; i >= 0 ; i--) {
			TileCategory category = categories[i];
			category.Hashing();
			_dictionary.Add(category.name, category);
		}
	}

	public	TileCategory FindCategory(string name) {
		if (_dictionary.ContainsKey(name))
			return _dictionary[name];
		else
			return null;
	}
}


public	class TileCategory {
	[XmlAttribute("name")]
	public	string							name;
	[XmlElement("Item")]
	public	TileItem[]						items;
	private	Dictionary<string, TileItem>	_dictionary;

	public	TileCategory() {
		name		= string.Empty;
		items		= new TileItem[0];
		_dictionary	= new Dictionary<string, TileItem>();
	}

	public	void Hashing() {
		_dictionary.Clear();
		for (int i = items.Length-1 ; i>=0 ; i--) {
			TileItem item = items[i];
			_dictionary.Add(item.id, item);
		}
	}

	public	TileItem FindItem(string id) {
		if (_dictionary.ContainsKey(id))
			return _dictionary[name];
		else
			return null;
	}
}

public	class TileItem {
	[XmlAttribute("id")]
	public	string	id;
	[XmlAttribute("asset")]
	public	string	asset;
	[XmlAttribute("cube")]
	public	bool	cube;
	[XmlAttribute("pivotX")]
	public	int		pivotX;
	[XmlAttribute("pivotY")]
	public	int		pivotY;
}