class Dot {
	constructor(obj) {
		Object.assign(this, obj);
	}

	create() {
		var group = new Konva.Group({
			x: this.positionX,
			y: this.positionY,
			id: this.id
		});
		layer.add(group);

		let circle = new Konva.Circle({
			x: this.positionX,
			y: this.positionY,
			radius: this.radius,
			fill: this.color,
			stroke: 'black',
			strokeWidth: 4,
		});

		if (this.hasOwnProperty('posts')) {
			for (let n in this.posts) {
				let text = new Konva.Text({
					y: this.positionY + this.radius + n * 25 + 5,
					text: this.posts[n].text,
					fontSize: 15,
					fontFamily: 'Calibri',
					fill: 'green',
				});
				let rect = new Konva.Rect({
					x: this.positionX - text.width() / 2,
					y: text.attrs.y - 3,
					stroke: '#555',
					strokeWidth: 2,
					width: text.width(),
					fill: this.posts[n].backgroundColor,
					height: 20,
				});
				text.attrs.x = rect.attrs.x;
				group.add(rect);
				group.add(text);
			}
		}

		circle.on('dblclick', function () {
			axios.delete(`api/Dots/Delete/${group.attrs.id}`);
			group.destroy();
			console.log("Tochka udalena");
		});
		group.add(circle);
	}

}

async function GetData() {
	await axios.get('api/Dots')
		.then(response => {
			response.data.map(x => new Dot(x).create());
			return true;
		})
		.catch((error) => {
			if (error.response) {
				console.log(error);
				return false;
			}
		});
}

let stage = new Konva.Stage({
	container: 'DotsContainer',
	width: window.innerWidth,
	height: window.innerHeight,
});

let layer = new Konva.Layer();
stage.add(layer);

GetData();