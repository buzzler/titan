using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("Config")]
public	class TileConfig {
	[XmlElement("Library")]
	public	TileLibrary	library;
	[XmlElement("Tutorial")]
	public	TileTutorial tutorial;

	public	static TileConfig LoadFromText(string text) {
		var serializer = new XmlSerializer(typeof(TileConfig));
		return serializer.Deserialize(new StringReader(text)) as TileConfig;
	}
}

public class TileLibrary {
	[XmlAttribute("path")]
	public	string	path;
	[XmlElement("Category")]
	public	TileCategory[]						categories;
	[XmlElement("Simple")]
	public	TileSimple[]						simples;
	[XmlElement("Complex")]
	public	TileComplex[]						complexs;
	[XmlElement("Direction")]
	public	TileDirection[]						directions;

	private	Dictionary<string, TileCategory>	_dictionaryCategory;
	private	Dictionary<string, TileItemBase>	_dictionaryItem;

	public	TileLibrary() {
		categories = new TileCategory[0];
		simples = new TileSimple[0];
		complexs = new TileComplex[0];
		directions = new TileDirection[0];
		_dictionaryCategory = new Dictionary<string, TileCategory>();
		_dictionaryItem = new Dictionary<string, TileItemBase>();
	}

	public	void Hashing() {
		_dictionaryCategory.Clear();
		_dictionaryItem.Clear();

		for (int i = categories.Length-1 ; i >= 0 ; i--) {
			TileCategory category = categories[i];
			category.Hashing();
			_dictionaryCategory.Add(category.name, category);
			for (int j = category.items.Length ; j >= 0 ; j--) {
				TileItem item = category.items[j];
				item.library = this;
				_dictionaryItem.Add(item.id, item);
			}
		}

		for (int i = simples.Length-1 ; i >= 0 ; i--) {
			TileSimple simple = simples[i];
			simple.library = this;
			_dictionaryItem.Add(simple.id, simple);
		}

		for (int i = complexs.Length-1 ; i >= 0 ; i--) {
			TileComplex complex = complexs[i];
			complex.library = this;
			_dictionaryItem.Add(complex.id, complex);
		}

		for (int i = directions.Length-1 ; i >= 0 ; i--) {
			TileDirection direction = directions[i];
			direction.library = this;
			_dictionaryItem.Add(direction.id, direction);
		}
	}

	public	TileCategory FindCategory(string name) {
		if (_dictionaryCategory.ContainsKey(name)) {
			return _dictionaryCategory[name];
		} else {
			return null;
		}
	}

	public	TileItemBase FindItem(string id) {
		if (_dictionaryItem.ContainsKey(id)) {
			return _dictionaryItem[id];
		} else {
			return null;
		}
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
		if (_dictionary.ContainsKey(id)) {
			return _dictionary[name];
		} else {
			return null;
		}
	}
}

public	class TileItem : TileItemBase {
//	[XmlAttribute("id")]
//	public	string	id;
	[XmlAttribute("asset")]
	public	string	asset;
	[XmlAttribute("cube")]
	public	bool	cube;
	[XmlAttribute("pivotX")]
	public	int		pivotX;
	[XmlAttribute("pivotY")]
	public	int		pivotY;
}

public	class TileItemBase {
	[XmlAttribute("id")]
	public	string	id;
	public	TileLibrary library;
}

public	class TileSimple : TileItemBase {
//	[XmlAttribute("id")]
//	public	string	id;
	[XmlElement("None")]
	public	TileItemLink	none;
	[XmlElement("U")]
	public	TileItemLink	up;
	[XmlElement("D")]
	public	TileItemLink	down;
	[XmlElement("L")]
	public	TileItemLink	left;
	[XmlElement("R")]
	public	TileItemLink	right;
	[XmlElement("UD")]
	public	TileItemLink	updown;
	[XmlElement("UL")]
	public	TileItemLink	upleft;
	[XmlElement("UR")]
	public	TileItemLink	upright;
	[XmlElement("DL")]
	public	TileItemLink	downleft;
	[XmlElement("DR")]
	public	TileItemLink	downright;
	[XmlElement("LR")]
	public	TileItemLink	leftright;
	[XmlElement("UDL")]
	public	TileItemLink	updownleft;
	[XmlElement("UDR")]
	public	TileItemLink	updownright;
	[XmlElement("DLR")]
	public	TileItemLink	downleftright;
	[XmlElement("UDLR")]
	public	TileItemLink	updownleftright;
}

public	class TileComplex : TileItemBase {
//	[XmlAttribute("id")]
//	public	string	id;
	[XmlElement("None")]
	public	TileItemLink	none;
	[XmlElement("U_1C")]
	public	TileItemLink	up_1c;
	[XmlElement("D_1C")]
	public	TileItemLink	down_1c;
	[XmlElement("L_1C")]
	public	TileItemLink	left_1c;
	[XmlElement("R_1C")]
	public	TileItemLink	right_1c;
	[XmlElement("U_1S")]
	public	TileItemLink	up_1s;
	[XmlElement("D_1S")]
	public	TileItemLink	down_1s;
	[XmlElement("L_1S")]
	public	TileItemLink	left_1s;
	[XmlElement("R_1S")]
	public	TileItemLink	right_1s;
	[XmlElement("LU_1C1S")]
	public	TileItemLink	leftup_1c1s;
	[XmlElement("DU_1C1S")]
	public	TileItemLink	downup_1c1s;
	[XmlElement("RD_1C1S")]
	public	TileItemLink	rightdown_1c1s;
	[XmlElement("UD_1C1S")]
	public	TileItemLink	updown_1c1s;
	[XmlElement("RL_1C1S")]
	public	TileItemLink	rightleft_1c1s;
	[XmlElement("DL_1C1S")]
	public	TileItemLink	downleft_1c1s;
	[XmlElement("LR_1C1S")]
	public	TileItemLink	leftright_1c1s;
	[XmlElement("UR_1C1S")]
	public	TileItemLink	upright_1c1s;
	[XmlElement("DLU_2C1S")]
	public	TileItemLink	downleftup_2c1s;
	[XmlElement("URD_2C1S")]
	public	TileItemLink	uprightdown_2c1s;
	[XmlElement("DRL_2C1S")]
	public	TileItemLink	downrightleft_2c1s;
	[XmlElement("ULR_2C1S")]
	public	TileItemLink	upleftright_2c1s;
	[XmlElement("DL_2C")]
	public	TileItemLink	downleft_2c;
	[XmlElement("UR_2C")]
	public	TileItemLink	upright_2c;
	[XmlElement("UD_2C")]
	public	TileItemLink	updown_2c;
	[XmlElement("LR_2C")]
	public	TileItemLink	leftright_2c;
	[XmlElement("UL_2C")]
	public	TileItemLink	upleft_2c;
	[XmlElement("DR_2C")]
	public	TileItemLink	downright_2c;
	[XmlElement("UR_2S")]
	public	TileItemLink	upright_2s;
	[XmlElement("DR_2S")]
	public	TileItemLink	downright_2s;
	[XmlElement("DL_2S")]
	public	TileItemLink	downleft_2s;
	[XmlElement("UL_2S")]
	public	TileItemLink	upleft_2s;
	[XmlElement("UD_2S")]
	public	TileItemLink	updown_2s;
	[XmlElement("LR_2S")]
	public	TileItemLink	leftright_2s;
	[XmlElement("UDR_1C2S")]
	public	TileItemLink	updownright_1c2s;
	[XmlElement("RDL_1C2S")]
	public	TileItemLink	rightdownleft_1c2s;
	[XmlElement("DUL_1C2S")]
	public	TileItemLink	downupleft_1c2s;
	[XmlElement("LUR_1C2S")]
	public	TileItemLink	leftupright_1c2s;
	[XmlElement("DLR_3C")]
	public	TileItemLink	downleftright_3c;
	[XmlElement("UDR_3C")]
	public	TileItemLink	updownright_3c;
	[XmlElement("UDL_3C")]
	public	TileItemLink	updownleft_3c;
	[XmlElement("ULR_3C")]
	public	TileItemLink	upleftright_3c;
	[XmlElement("DLR_3S")]
	public	TileItemLink	downleftright_3s;
	[XmlElement("ULR_3S")]
	public	TileItemLink	upleftright_3s;
	[XmlElement("UDR_3S")]
	public	TileItemLink	updownright_3s;
	[XmlElement("UDL_3S")]
	public	TileItemLink	updownleft_3s;
	[XmlElement("UDLR_4C")]
	public	TileItemLink	updownleftright_4c;
	[XmlElement("UDLR_4S")]
	public	TileItemLink	updownleftright_4s;
}

public	class TileDirection : TileItemBase {
//	[XmlAttribute("id")]
//	public	string	id;
	[XmlElement("U")]
	public	TileItemLink	up;
	[XmlElement("D")]
	public	TileItemLink	down;
	[XmlElement("L")]
	public	TileItemLink	left;
	[XmlElement("R")]
	public	TileItemLink	right;
}

public	class TileItemLink {
	[XmlAttribute("item")]
	public	string			item;
	[XmlElement("Child")]
	public	TileItemLink[]	children;
}

public	class TileTutorial {
	[XmlElement("Map")]
	public	TileMap[]	maps;
	private	Dictionary<string, TileMap>	_dictionaryMap;

	public	TileTutorial() {
		maps = new TileMap[0];
		_dictionaryMap = new Dictionary<string, TileMap>();
	}

	public	void Hashing() {
		_dictionaryMap.Clear();
		for (int i = maps.Length-1 ; i >= 0 ; i--) {
			TileMap map = maps[i];
			map.Sort();
			_dictionaryMap.Add(map.id, map);
		}
	}
}

public	class TileMap {
	[XmlAttribute("id")]
	public	string	id;
	[XmlElement("Terrain")]
	public	TileTerrain[]	terrains;

	public	void Sort() {
	}
}

public	class TileTerrain {
	[XmlAttribute("asset")]
	public	string asset;
	[XmlAttribute("x")]
	public	int	x;
	[XmlAttribute("y")]
	public	int y;
	[XmlAttribute("z")]
	public	int z;
}